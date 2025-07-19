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
    public class TabletsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TabletsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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

        // GET: Tablets
        [Authorize(Roles = "Administrator, Default")]
        public async Task<IActionResult> Index()
        {
            var tenantId = (await GetTenantIdAsync())?.Trim();
            if (tenantId == null) return Unauthorized();

            var filtered = await _context.Tablets.Where(c => c.TenantId == tenantId).ToListAsync();

            return View(filtered);
        }

        // GET: Tablets/Details/5
        [Authorize(Roles = "Administrator, Default")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tablets == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadTablet = await _context.Tablets
                .FirstOrDefaultAsync(m => m.Id == id && m.TenantId == tenantId);

            if (cadTablet == null) return NotFound();

            return View(cadTablet);
        }

        // GET: Tablets/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tablets == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadTablet = await _context.Tablets.FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (cadTablet == null) return NotFound();

            return View(cadTablet);
        }

        // POST: Tablets/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Unidade,Depto,Fabricante,Modelo,Ns,Patrimonio,Id")] CadTablet cadTablet)
        {
            if (id != cadTablet.Id) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var computadorExistente = await _context.Tablets
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (computadorExistente == null) return NotFound();

            cadTablet.TenantId = tenantId;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadTablet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadTabletExists(cadTablet.Id, tenantId))
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
            return View(cadTablet);
        }

        // GET: Tablets/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tablets == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadTablet = await _context.Tablets
                .FirstOrDefaultAsync(m => m.Id == id && m.TenantId == tenantId);

            if (cadTablet == null) return NotFound();

            return View(cadTablet);
        }

        // POST: Tablets/Delete/5
        [HttpPost, ActionName("DeleteAjax")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAjax(int id)
        {
            if (_context.Tablets == null)
            {
                return Json(new { success = false, message = "Erro no banco de dados." });
            }

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null)
            {
                return Json(new { success = false, message = "Não autorizado." });
            }

            var cadTablet = await _context.Tablets.FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (cadTablet == null)
            {
                return Json(new { success = false, message = "Computador não encontrado." });
            }

            _context.Tablets.Remove(cadTablet);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Registro excluído com sucesso!" });
        }

        private bool CadTabletExists(int id, string tenantId)
        {
          return _context.Tablets.Any(e => e.Id == id && e.TenantId == tenantId);
        }
    }
}
