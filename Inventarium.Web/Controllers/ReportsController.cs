using InventariumWebApp.Data;
using InventariumWebApp.Models.ViewModels;
using InventariumWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Inventarium.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // PDF
        public IActionResult PcReportPdf() => GeneratePdf(new ReportViewModel { Computers = _context.Computers.ToList(), ReportType = "Desktops" }, "PC Report");

        public IActionResult NoteReportPdf() => GeneratePdf(new ReportViewModel { Notebooks = _context.Notebooks.ToList(), ReportType = "Notebooks" }, "Notebook Report");

        public IActionResult MonitorReportPdf() => GeneratePdf(new ReportViewModel { Monitors = _context.Displays.ToList(), ReportType = "Monitors" }, "Monitor Report");

        public IActionResult PrinterReportPdf() => GeneratePdf(new ReportViewModel { Printers = _context.Printers.ToList(), ReportType = "Printers" }, "Printer Report");

        public IActionResult NetworkReportPdf() => GeneratePdf(new ReportViewModel { Networks = _context.Networks.ToList(), ReportType = "Networks" }, "Network Report");

        public IActionResult TabletReportPdf() => GeneratePdf(new ReportViewModel { Tablets = _context.Tablets.ToList(), ReportType = "Tablets" }, "Tablet Report");

        public IActionResult AllAssetsReportPdf() => GeneratePdf(new ReportViewModel
        {
            Computers = _context.Computers.ToList(),
            Notebooks = _context.Notebooks.ToList(),
            Monitors = _context.Displays.ToList(),
            Printers = _context.Printers.ToList(),
            Networks = _context.Networks.ToList(),
            Tablets = _context.Tablets.ToList(),
            ReportType = "Todos"
        }, "All Assets Report");

        // Excel
        public IActionResult PcReportExcel() => GenerateExcel(new ReportViewModel { Computers = _context.Computers.ToList(), ReportType = "Desktops" }, "PC Report");

        public IActionResult NoteReportExcel() => GenerateExcel(new ReportViewModel { Notebooks = _context.Notebooks.ToList(), ReportType = "Notebooks" }, "Notebook Report");

        public IActionResult MonitorReportExcel() => GenerateExcel(new ReportViewModel { Monitors = _context.Displays.ToList(), ReportType = "Monitors" }, "Monitor Report");

        public IActionResult PrinterReportExcel() => GenerateExcel(new ReportViewModel { Printers = _context.Printers.ToList(), ReportType = "Printers" }, "Printer Report");

        public IActionResult NetworkReportExcel() => GenerateExcel(new ReportViewModel { Networks = _context.Networks.ToList(), ReportType = "Networks" }, "Network Report");

        public IActionResult TabletReportExcel() => GenerateExcel(new ReportViewModel { Tablets = _context.Tablets.ToList(), ReportType = "Tablets" }, "Tablet Report");

        public IActionResult AllAssetsReportExcel() => GenerateExcel(new ReportViewModel
        {
            Computers = _context.Computers.ToList(),
            Notebooks = _context.Notebooks.ToList(),
            Monitors = _context.Displays.ToList(),
            Printers = _context.Printers.ToList(),
            Networks = _context.Networks.ToList(),
            Tablets = _context.Tablets.ToList(),
            ReportType = "Todos"
        }, "All Assets Report");

        // Helpers
        private IActionResult GeneratePdf(ReportViewModel model, string title)
        {
            var pdf = ReportGenerator.GeneratePdf(model, title);
            return File(pdf, "application/pdf", $"{title}.pdf");
        }

        private IActionResult GenerateExcel(ReportViewModel model, string title)
        {
            var excel = ReportGenerator.GenerateExcel(model, title);
            return File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{title}.xlsx");
        }
    }
}
