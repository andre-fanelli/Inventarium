using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventariumWebApp.Data;
using InventariumWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace InventariumWebApp.Controllers
{
    public class ComputersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ComputersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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

        // GET: Computers
        [Authorize(Roles = "Administrator, Default")]
        public async Task<IActionResult> Index()
        {
            var tenantId = (await GetTenantIdAsync())?.Trim();
            if (tenantId == null) return Unauthorized();

            var filtered = await _context.Computers.Where(c => c.TenantId == tenantId).ToListAsync();

            return View(filtered);

        }

        // GET: Computers/Details/5
        [Authorize(Roles = "Administrator,Default")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Computers == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadPc = await _context.Computers
                .FirstOrDefaultAsync(m => m.Id == id && m.TenantId == tenantId);

            if (cadPc == null) return NotFound();

            return View(cadPc);
        }

        // GET: Computers/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Computers == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadPc = await _context.Computers.FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (cadPc == null) return NotFound();

            return View(cadPc);
        }

        // POST: Computers/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Unidade,Depto,Processador,Ram,Storage,Hostname,Fabricante,Modelo,Ns,Patrimonio,So")] CadPc cadPc)
        {
            if (id != cadPc.Id) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var computadorExistente = await _context.Computers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (computadorExistente == null) return NotFound();

            cadPc.TenantId = tenantId;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadPc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadPcExists(cadPc.Id, tenantId))
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
            return View(cadPc);
        }

        // GET: Computers/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Computers == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadPc = await _context.Computers
                .FirstOrDefaultAsync(m => m.Id == id && m.TenantId == tenantId);

            if (cadPc == null) return NotFound();

            return View(cadPc);
        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("DeleteAjax")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAjax(int? id)
        {
            if (_context.Computers == null)
            {
                return Json(new { success = false, message = "Erro no banco de dados." });
            }

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null)
            {
                return Json(new { success = false, message = "Não autorizado." });
            }

            var cadPc = await _context.Computers
               .FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (cadPc == null)
            {
                return Json(new { success = false, message = "Computador não encontrado." });
            }

            _context.Computers.Remove(cadPc);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message ="Registro excluído com sucesso!" });
        }

        private bool CadPcExists(int id, string tenantId)
        {
          return _context.Computers.Any(e => e.Id == id && e.TenantId == tenantId);
        }
    }
}
