using InventariumWebApp.Models.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System.IO;
using System.Linq;

namespace InventariumWebApp.Services
{
    public static class ReportGenerator
    {
        public static byte[] GeneratePdf(ReportViewModel report, string title)
        {
            using var ms = new MemoryStream();
            var document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, ms);
            document.Open();

            document.Add(new Paragraph(title));
            document.Add(new Paragraph(" "));

            // Desktops
            if (report.ReportType == "Desktops" || report.ReportType == "Todos")
            {
                document.Add(new Paragraph("=== Desktops ==="));
                document.Add(new Paragraph("Hostname | Processador | RAM (GB) | Armazenamento (GB) | Fabricante | Modelo | Nº de Série | Patrimônio | Sistema Operacional"));
                foreach (var pc in report.Computers)
                    document.Add(new Paragraph($"{pc.Hostname} - {pc.Processador} - {pc.Ram} - {pc.Storage} - {pc.Fabricante} - {pc.Modelo} - {pc.Ns} - {pc.Patrimonio} - {pc.So}"));
                document.Add(new Paragraph(" "));
            }

            // Notebooks
            if (report.ReportType == "Notebooks" || report.ReportType == "Todos")
            {
                document.Add(new Paragraph("=== Notebooks ==="));
                document.Add(new Paragraph("Hostname | Processador | RAM (GB) | Armazenamento (GB) | Fabricante | Modelo | Nº de Série | Patrimônio | Sistema Operacional"));
                foreach (var note in report.Notebooks)
                    document.Add(new Paragraph($"{note.Hostname} - {note.Processador} - {note.Ram} - {note.Storage} - {note.Fabricante} - {note.Modelo} - {note.Ns} - {note.Patrimonio} - {note.So}"));
                document.Add(new Paragraph(" "));
            }

            // Monitores
            if (report.ReportType == "Monitors" || report.ReportType == "Todos")
            {
                document.Add(new Paragraph("=== Monitors ==="));
                document.Add(new Paragraph("Fabricante | Modelo | Nº de Série | Patrimônio"));
                foreach (var mon in report.Monitors)
                    document.Add(new Paragraph($"{mon.Fabricante} - {mon.Modelo} - {mon.Ns} - {mon.Patrimonio}"));
                document.Add(new Paragraph(" "));
            }

            // Impressoras
            if (report.ReportType == "Printers" || report.ReportType == "Todos")
            {
                document.Add(new Paragraph("=== Printers ==="));
                document.Add(new Paragraph("Fabricante | Modelo | Tipo | Nº de Série | Patrimônio"));
                foreach (var printer in report.Printers)
                    document.Add(new Paragraph($"{printer.Fabricante} - {printer.Modelo} - {printer.Tipo} - {printer.Ns} - {printer.Patrimonio}"));
                document.Add(new Paragraph(" "));
            }

            // Redes
            if (report.ReportType == "Networks" || report.ReportType == "Todos")
            {
                document.Add(new Paragraph("=== Network Equipments ==="));
                document.Add(new Paragraph("Fabricante | Modelo | Tipo | Nº de Série | Patrimônio"));
                foreach (var net in report.Networks)
                    document.Add(new Paragraph($"{net.Fabricante} - {net.Modelo} - {net.Tipo} - {net.Ns} - {net.Patrimonio}"));
                document.Add(new Paragraph(" "));
            }

            // Tablets
            if (report.ReportType == "Tablets" || report.ReportType == "Todos")
            {
                document.Add(new Paragraph("=== Tablets ==="));
                document.Add(new Paragraph("Fabricante | Modelo | Nº de Série | Patrimônio"));
                foreach (var tab in report.Tablets)
                    document.Add(new Paragraph($"{tab.Fabricante} - {tab.Modelo} - {tab.Ns} - {tab.Patrimonio}"));
                document.Add(new Paragraph(" "));
            }

            document.Close();
            return ms.ToArray();
        }

        public static byte[] GenerateExcel(ReportViewModel report, string title)
        {
            using var package = new ExcelPackage();

            void AddSheet<T>(IEnumerable<T> items, string sheetName, params string[] properties)
            {
                if (!items.Any()) return;

                var ws = package.Workbook.Worksheets.Add(sheetName);
                for (int i = 0; i < properties.Length; i++)
                    ws.Cells[1, i + 1].Value = properties[i];

                int row = 2;
                foreach (var item in items)
                {
                    var props = typeof(T).GetProperties();
                    for (int col = 0; col < properties.Length; col++)
                    {
                        var val = props.FirstOrDefault(p => p.Name == properties[col])?.GetValue(item);
                        ws.Cells[row, col + 1].Value = val;
                    }
                    row++;
                }
            }

            if (report.ReportType == "Desktops" || report.ReportType == "Todos")
                AddSheet(report.Computers, "Desktops", "Id", "Hostname", "Processador", "Ram", "Storage", "Fabricante", "Modelo", "Ns", "Patrimonio", "So");

            if (report.ReportType == "Notebooks" || report.ReportType == "Todos")
                AddSheet(report.Notebooks, "Notebooks", "Id", "Hostname", "Processador", "Ram", "Storage", "Fabricante", "Modelo", "Ns", "Patrimonio", "So");

            if (report.ReportType == "Monitors" || report.ReportType == "Todos")
                AddSheet(report.Monitors, "Monitors", "Id", "Fabricante", "Modelo", "Ns", "Patrimonio", "Unidade", "Depto");

            if (report.ReportType == "Printers" || report.ReportType == "Todos")
                AddSheet(report.Printers, "Printers", "Id", "Fabricante", "Modelo", "Tipo", "Ns", "Patrimonio", "Unidade", "Depto");

            if (report.ReportType == "Networks" || report.ReportType == "Todos")
                AddSheet(report.Networks, "Networks", "Id", "Fabricante", "Modelo", "Tipo", "Ns", "Patrimonio", "Unidade", "Depto");

            if (report.ReportType == "Tablets" || report.ReportType == "Todos")
                AddSheet(report.Tablets, "Tablets", "Id", "Fabricante", "Modelo", "Ns", "Patrimonio", "Unidade", "Depto");

            return package.GetAsByteArray();
        }
    }
}
