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
    public class PrintersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PrintersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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

        // GET: Printers
        [Authorize(Roles = "Administrator, Default")]
        public async Task<IActionResult> Index()
        {
            var tenantId = (await GetTenantIdAsync())?.Trim();
            if (tenantId == null) return Unauthorized();

            var filtered = await _context.Printers.Where(c => c.TenantId == tenantId).ToListAsync();

            return View(filtered);
        }

        // GET: Printers/Details/5
        [Authorize(Roles = "Administrator, Default")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Printers == null)
            {
                return NotFound();
            }

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadImpressora = await _context.Printers
                .FirstOrDefaultAsync(m => m.Id == id && m.TenantId == tenantId);

            if (cadImpressora == null) return NotFound();

            return View(cadImpressora);
        }


        // GET: Printers/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Printers == null)
            {
                return NotFound();
            }

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadImpressora = await _context.Printers.FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);
            if (cadImpressora == null) return NotFound();

            return View(cadImpressora);
        }

        // POST: Printers/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Unidade,Depto,Fabricante,Modelo,Tipo,Ns,Patrimonio,Id")] CadImpressora cadImpressora)
        {
            if (id != cadImpressora.Id) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var impressoraExistente = await _context.Printers.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (impressoraExistente == null) return NotFound();

            cadImpressora.TenantId= tenantId;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadImpressora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadImpressoraExists(cadImpressora.Id, tenantId))
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
            return View(cadImpressora);
        }

        // GET: Printers/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Printers == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadImpressora = await _context.Printers
                .FirstOrDefaultAsync(m => m.Id == id && m.TenantId == tenantId);

            if (cadImpressora == null) return NotFound();

            return View(cadImpressora);
        }

        // POST: Printers/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAjax(int? id)
        {
            if (_context.Printers == null)
            {
                return Json(new { success = false, message = "Erro no banco de dados." });
            }

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null)
            {
                return Json(new { success = false, message = "Não autorizado." });
            }

            var cadImpressora = await _context.Printers.FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (cadImpressora == null)
            {
                return Json(new { success = false, message = "Computador não encontrado." });
            }
            
            _context.Printers.Remove(cadImpressora);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Registro excluído com sucesso!" });
        }

        private bool CadImpressoraExists(int id, string tenantId)
        {
          return _context.Printers.Any(e => e.Id == id && e.TenantId == tenantId);
        }
    }
}
