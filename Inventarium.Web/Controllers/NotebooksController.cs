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
    public class NotebooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public NotebooksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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

        // GET: Notebooks
        [Authorize(Roles = "Administrator, Default")]
        public async Task<IActionResult> Index()
        {
            var tenantId = (await GetTenantIdAsync())?.Trim();
            if (tenantId == null) return Unauthorized();

            var filtered = await _context.Notebooks.Where(c => c.TenantId == tenantId).ToListAsync();

            return View(filtered);
        }

        // GET: Notebooks/Details/5
        [Authorize(Roles = "Administrator, Default")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notebooks == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadNote = await _context.Notebooks
                .FirstOrDefaultAsync(m => m.Id == id && m.TenantId == tenantId);

            if (cadNote == null) return NotFound();

            return View(cadNote);
        }

        // GET: Notebooks/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notebooks == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadNote = await _context.Notebooks.FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (cadNote == null) return NotFound();

            return View(cadNote);
        }

        // POST: Notebooks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Unidade,Depto,Processador,Ram,Storage,Hostname,Fabricante,Modelo,Ns,Patrimonio,So,Id")] CadNote cadNote)
        {
            if (id != cadNote.Id) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var notebookExistente = await _context.Notebooks.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (notebookExistente == null) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadNoteExists(cadNote.Id, tenantId))
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
            return View(cadNote);
        }

        // GET: Notebooks/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notebooks == null) return NotFound();

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null) return Unauthorized();

            var cadNote = await _context.Notebooks
                .FirstOrDefaultAsync(m => m.Id == id && m.TenantId == tenantId);

            if (cadNote == null) return NotFound();

            return View(cadNote);
        }

        // POST: Notebooks/Delete/5
        [HttpPost, ActionName("DeleteAjax")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAjax(int? id)
        {
            if (_context.Notebooks == null)
            {
                return Json(new { success = false, message = "Erro no banco de dados." });
            }

            var tenantId = await GetTenantIdAsync();
            if (tenantId == null)
            {
                return Json(new { success = false, message = "Não autorizado." });
            }

            var cadNote = await _context.Notebooks.FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

            if (cadNote == null)
            {
                return Json(new { success = false, message = "Notebook não encontrado." });
            }

            _context.Notebooks.Remove(cadNote);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Registro excluído com sucesso!" });
        }
        private bool CadNoteExists(int id, string tenantId)
        {
          return _context.Notebooks.Any(e => e.Id == id && e.TenantId == tenantId);
        }
    }
}
