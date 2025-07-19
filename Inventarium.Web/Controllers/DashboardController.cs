using InventariumWebApp.Data;
using InventariumWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventariumWebApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _environment = environment;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> GerarExecutavel()
    {
        var user = await _userManager.GetUserAsync(User);
        var tenantId = user.TenantId;

        // Caminho para o template do executável
        var templatePath = Path.Combine(_environment.WebRootPath, "executavel_base", "InventariumTemplate.exe");

        // Novo executável com nome customizado
        var outputPath = Path.Combine(_environment.WebRootPath, "executavel_gerado", $"Inventarium_{tenantId}.exe");

        // Simula a geração do EXE personalizado (copiando template)
        System.IO.Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        System.IO.File.Copy(templatePath, outputPath, true);

        // Aqui você pode injetar o TenantId via embed (ainda vamos implementar isso via Roslyn ou outro método)

        // Retorna como download
        var fileBytes = await System.IO.File.ReadAllBytesAsync(outputPath);
        return File(fileBytes, "application/octet-stream", $"Inventarium_{tenantId}.exe");
    }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var tenantId = user.TenantId?.Trim();
            if (tenantId == null) return Unauthorized();

            // Populando os contadores para os cards no Dashboard
            ViewBag.ComputersCount = await _context.Computers.CountAsync(c => c.TenantId == tenantId);
            ViewBag.NotebooksCount = await _context.Notebooks.CountAsync(c => c.TenantId == tenantId);
            ViewBag.DisplaysCount = await _context.Displays.CountAsync(c => c.TenantId == tenantId);
            ViewBag.PrintersCount = await _context.Printers.CountAsync(c => c.TenantId == tenantId);
            ViewBag.NetworksCount = await _context.Networks.CountAsync(c => c.TenantId == tenantId);
            ViewBag.TabletsCount = await _context.Tablets.CountAsync(c => c.TenantId == tenantId);

            return View();
        }
    }
}
