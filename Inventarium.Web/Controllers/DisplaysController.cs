using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventariumWebApp.Data;
using InventariumWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace InventariumWebApp.Controllers
{
    public class DisplaysController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DisplaysController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private async Task<string?> GetTenantIdAsync()
        {
            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
                return null;

            var user = await _context.Users
                .Where(u => u.UserName == userName)
                .FirstOrDefaultAsync();

            return user?.TenantId;
        }

        // GET: Displays
        [Authorize(Roles = "Administrator, Default")]
        public async Task<IActionResult> Index()
        {
            var tenantId = (await GetTenantIdAsync())?.Trim();
            if (tenantId == null) return Unauthorized();

            var filtered = await _context.Displays.Where(c => c.TenantId == tenantId).ToListAsync();

            return View(filtered);
        }

        // GET: Displays/Details/5
        [Authorize(Roles = "Administrator, Default")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Displays == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadMonitor = await _context.Displays
                .FirstOrDefaultAsync(m => m.Id == id && m.TenantId == tenantId);

            if (cadMonitor == null) return NotFound();

            return View(cadMonitor);
        }

        // GET: Displays/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Displays == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadMonitor = await _context.Displays.FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (cadMonitor == null) return NotFound();

            return View(cadMonitor);
        }

        // POST: Displays/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Unidade,Depto,Fabricante,Modelo,Ns,Patrimonio,Id")] CadMonitor cadMonitor)
        {
            if (id != cadMonitor.Id) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var monitorExistente = await _context.Displays.AsNoTracking().
                FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (monitorExistente == null) return NotFound();

            cadMonitor.TenantId = tenantId;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadMonitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadMonitorExists(cadMonitor.Id, tenantId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cadMonitor);
        }

        // GET: Displays/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Displays == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadMonitor = await _context.Displays
                .FirstOrDefaultAsync(m => m.Id == id && m.TenantId == tenantId);

            if (cadMonitor == null) return NotFound();

            return View(cadMonitor);
        }

        // POST: Displays/Delete/5
        [HttpPost, ActionName("DeleteAjax")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAjax(int id)
        {
            if (_context.Displays == null)
            {
                return Json(new { success = false, message = "Erro no banco de dados." });
            }

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null)
            {
                return Json(new { success = false, message = "Não autorizado." });
            }

            var cadMonitor = await _context.Displays.
                FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (cadMonitor == null)
            {
                return Json(new { success = false, message = "Computador não encontrado." });
            }

            _context.Displays.Remove(cadMonitor);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Registro excluído com sucesso!" });
        }

        private bool CadMonitorExists(int id, string tenantId)
        {
          return _context.Displays.Any(e => e.Id == id && e.TenantId == tenantId);
        }
    }
}
