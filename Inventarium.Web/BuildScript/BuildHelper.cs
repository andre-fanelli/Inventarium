using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InventariumWebApp.BuildScript
{
    public static class BuildHelper
    {
        public static async Task<string> BuildExecutableAsync(string tenantId, string userEmail, IHubContext<BuildHub> hubContext)
        {
            var sourcePath = @"D:\Andre\Projetos\Visual Studio\Inventarium-Solution\InventariumDesktopApp";
            var tempPath = Path.Combine(Directory.GetCurrentDirectory(), "..","TempBuild", tenantId);

            // Garantir que a pasta esteja limpa
            var gitDir = Path.Combine(tempPath, ".git");
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }

            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }

            var tempDirectoryInfo = new DirectoryInfo(tempPath);
            tempDirectoryInfo.Attributes = FileAttributes.Normal;

            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", "Iniciando o processo de construção...");

            // Copiar tudo
            foreach (var dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                // Ignorar diretórios .git e outros que podem ter problemas de permissão
                if (dirPath.Contains(".git"))
                    continue;

                Directory.CreateDirectory(dirPath.Replace(sourcePath, tempPath));
            }

            foreach (var filePath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                // Ignorar arquivos dentro de diretórios .git
                if (filePath.Contains(".git"))
                    continue;

                try
                {
                    // Verificar se o arquivo tem permissão de leitura antes de copiar
                    var fileInfo = new FileInfo(filePath);
                    if (fileInfo.IsReadOnly || !File.Exists(filePath))
                        continue;

                    File.Copy(filePath, filePath.Replace(sourcePath, tempPath), true);
                }
                catch (UnauthorizedAccessException ex)
                {
                    // Log detalhado do erro
                    Console.WriteLine($"Erro ao acessar o arquivo {filePath}: {ex.Message}");
                    continue;
                }
                catch (Exception ex)
                {
                    // Log detalhado de outras exceções
                    Console.WriteLine($"Erro ao copiar arquivo {filePath}: {ex.Message}");
                }
            }

            // Enviar progresso após copiar os arquivos
            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", "Arquivos copiados, substituindo TenantId...");

            // Substituir o TenantId
            var appconfigCsPath = Directory.GetFiles(tempPath, "AppConfig.cs", SearchOption.AllDirectories).FirstOrDefault();
            if (appconfigCsPath != null)
            {
                var programText = await File.ReadAllTextAsync(appconfigCsPath);
                programText = programText.Replace("TENANT_ID_PLACEHOLDER", $"{tenantId}");
                await File.WriteAllTextAsync(appconfigCsPath, programText);
            }

            // Enviar progresso após substituir o TenantId
            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", "TenantId substituído com sucesso.");

            // Compilar usando MSBuild
            var msbuildPath = @"D:\Visual Studio\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\amd64\MSBuild.exe"; // Ajuste se necessário
            var solutionFile = Directory.GetFiles(tempPath, "*.sln", SearchOption.AllDirectories).FirstOrDefault();

            if (solutionFile == null)
                throw new Exception("Arquivo .sln não encontrado!");

            var processInfo = new ProcessStartInfo
            {
                FileName = msbuildPath,
                Arguments = $"\"{solutionFile}\" /p:Configuration=Release",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(processInfo);

            // Aqui você pode ler o processo de compilação e enviar mensagens de progresso em tempo real
            process.OutputDataReceived += (sender, args) =>
            {
                if (args.Data != null)
                {
                    // Envia as atualizações do processo de compilação para o cliente
                    hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", args.Data);
                }
            };

            process.BeginOutputReadLine();
            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
            {
                var error = await process.StandardError.ReadToEndAsync();
                throw new Exception($"Erro ao compilar: {error}");
            }

            // Enviar progresso final após a compilação
            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", "Compilação concluída, criando o arquivo zip...");

            // Zipar
            var releasePath = Directory.GetDirectories(tempPath, "Release", SearchOption.AllDirectories).FirstOrDefault();
            if (releasePath == null)
                throw new Exception("Pasta Release não encontrada!");

            var zipFileName = $"{tenantId}_{DateTime.Now:yyyyMMddHHmm}.zip";
            var zipPath = Path.Combine(Directory.GetCurrentDirectory(), "ExportBuilds", zipFileName);

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "ExportBuilds")))
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "ExportBuilds"));

            if (File.Exists(zipPath))
                File.Delete(zipPath);

            System.IO.Compression.ZipFile.CreateFromDirectory(releasePath, zipPath);

            // Enviar mensagem final com o caminho do arquivo
            await hubContext.Clients.All.SendAsync("ReceiveProgressUpdate", $"Arquivo gerado: {zipFileName}");


            return $"/exports/{zipFileName}";
        }
    }
}
