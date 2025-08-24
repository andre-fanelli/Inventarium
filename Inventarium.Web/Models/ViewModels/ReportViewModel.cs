using InventariumWebApp.Models;
using System.Collections.Generic;

namespace InventariumWebApp.Models.ViewModels
{
    public class ReportViewModel
    {
        public string ReportType { get; set; } = "All";

        public IEnumerable<CadPc> Computers { get; set; } = new List<CadPc>();
        public IEnumerable<CadNote> Notebooks { get; set; } = new List<CadNote>();
        public IEnumerable<CadMonitor> Monitors { get; set; } = new List<CadMonitor>();
        public IEnumerable<CadImpressora> Printers { get; set; } = new List<CadImpressora>();
        public IEnumerable<CadRede> Networks { get; set; } = new List<CadRede>();
        public IEnumerable<CadTablet> Tablets { get; set; } = new List<CadTablet>();
    }
}
