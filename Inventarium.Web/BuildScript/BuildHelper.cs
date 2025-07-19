using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InventariumWebApp.BuildScript
{
    public static class BuildHelper
    {
        public static async Task<string> BuildExecutableAsync(string tenantId, string userEmail, IHubContext<BuildHub> hubContext)
        {
            var sourcePath = @"D:\Andre\Projetos\Visual Studio\Inventarium\Inventarium.Desktop";
            var tempPath = Path.Combine(Directory.GetCurrentDirectory(), "..","TempBuild", tenantId);

            // Garantir que a pasta esteja limpa
            if (Directory.Exists(tempPath))
                Directory.Delete(tempPath, true);
            Directory.CreateDirectory(tempPath);

            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", "Copiando arquivos...");

            var tempDirectoryInfo = new DirectoryInfo(tempPath);
            tempDirectoryInfo.Attributes = FileAttributes.Normal;

            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", "Iniciando o processo de construção...");

            // Copiar todos os arquivos, exceto .git
            foreach (var dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                if (dirPath.Contains(".git")) continue;
                Directory.CreateDirectory(dirPath.Replace(sourcePath, tempPath));
            }

            foreach (var filePath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                if (filePath.Contains(".git")) continue;
                try
                {
                    var fileInfo = new FileInfo(filePath);
                    if (!fileInfo.IsReadOnly && File.Exists(filePath))
                        File.Copy(filePath, filePath.Replace(sourcePath, tempPath), true);
                }
                catch { continue; }
            }

            // Enviar progresso após copiar os arquivos
            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", "Substituindo TenantId...");

            // Substituir o TenantId
            var appconfigCsPath = Directory.GetFiles(tempPath, "AppConfig.cs", SearchOption.AllDirectories).FirstOrDefault();
            if (appconfigCsPath != null)
            {
                var programText = await File.ReadAllTextAsync(appconfigCsPath);
                programText = programText.Replace("TENANT_ID_PLACEHOLDER", $"{tenantId}");
                await File.WriteAllTextAsync(appconfigCsPath, programText);
            }

            // Enviar progresso após substituir o TenantId
            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", "TenantId substituído com sucesso!");

            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", "Iniciando compilação...");

            // Diretório de saída
            var publishPath = Path.Combine(Directory.GetCurrentDirectory(), "ExportBuilds", $"Inventarium_{tenantId}");
            if (Directory.Exists(publishPath)) Directory.Delete(publishPath, true);
            Directory.CreateDirectory(publishPath);

            // dotnet publish para gerar único EXE self-contained
            var processInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = $"publish \"{tempPath}\" -c Release -r win-x64 --self-contained false /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true -o \"{publishPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = new Process { StartInfo = processInfo };
            process.Start();

            // Leitura em tempo real
            while (!process.StandardOutput.EndOfStream)
            {
                var line = await process.StandardOutput.ReadLineAsync();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", line);
                }
            }

            // Leitura de erros
            string error = await process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
                throw new Exception($"Erro ao compilar: {error}");


            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", "Compilação concluída!");

            // Localizar o .exe gerado
            var exePath = Directory.GetFiles(publishPath, "*.exe").FirstOrDefault();
            if (exePath == null)
                throw new Exception("Executável não encontrado!");

            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", $"Pronto para download: {Path.GetFileName(exePath)}");

            // Enviar progresso final após a compilação
            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", "Compilação concluída!");

            // Encontrar o executável gerado
            exePath = Directory.GetFiles(publishPath, "*.exe").FirstOrDefault();
            if (exePath == null)
                throw new Exception("Executável não encontrado após publicação!");

            var exportFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "exports");
            if (!Directory.Exists(exportFolder))
                Directory.CreateDirectory(exportFolder);

            var fileName = $"Inventarium_{DateTime.Now:yyyyMMddHHmm}.exe";
            var finalExePath = Path.Combine(exportFolder, fileName);

            File.Copy(exePath, finalExePath, true);

            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", $"Executável gerado: {fileName}");

            return $"/exports/{fileName}";
        }
    }
}
