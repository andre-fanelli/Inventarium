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
    public class NetworksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public NetworksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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

        // GET: Networks
        [Authorize(Roles = "Administrator, Default")]
        public async Task<IActionResult> Index()
        {
            var tenantId = (await GetTenantIdAsync())?.Trim();
            if (tenantId == null) return Unauthorized();

            var filtered = await _context.Networks.Where(c => c.TenantId == tenantId).ToListAsync();

            return View(filtered);
        }

        // GET: Networks/Details/5
        [Authorize(Roles = "Administrator, Default")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Networks == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadRede = await _context.Networks.FirstOrDefaultAsync(m => m.Id == id && m.TenantId == tenantId);

            if (cadRede == null) return NotFound();

            return View(cadRede);
        }

        // GET: Networks/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Networks == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadRede = await _context.Networks.FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (cadRede == null) return NotFound();

            return View(cadRede);
        }

        // POST: Networks/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Unidade,Depto,Fabricante,Modelo,Tipo,Ns,Patrimonio,Id")] CadRede cadRede)
        {
            if (id != cadRede.Id) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var ativoRedeExistente = await _context.Networks
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (ativoRedeExistente == null) return NotFound();

            cadRede.TenantId = tenantId;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadRede);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadRedeExists(cadRede.Id, tenantId))
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
            return View(cadRede);
        }

        // GET: Networks/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Networks == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadRede = await _context.Networks
                .FirstOrDefaultAsync(m => m.Id == id && m.TenantId == tenantId);

            if (cadRede == null) return NotFound();

            return View(cadRede);
        }

        // POST: Networks/Delete/5
        [HttpPost, ActionName("DeleteAjax")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAjax(int id)
        {
            if (_context.Networks == null)
            {
                return Json(new { success = false, message = "Erro no banco de dados." });
            }

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null)
            {
                return Json(new { success = false, message = "Não autorizado." });
            }

            var cadRede = await _context.Networks.FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (cadRede == null)
            {
                return Json(new { success = false, message = "Computador não encontrado." });
            }

            _context.Networks.Remove(cadRede);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Registro excluído com sucesso!" });
        }

        private bool CadRedeExists(int id, string tenantId)
        {
          return _context.Networks.Any(e => e.Id == id && e.TenantId == tenantId);
        }
    }
}
