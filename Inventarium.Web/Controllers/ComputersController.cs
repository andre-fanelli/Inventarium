using InventariumWebApp.Data;
using InventariumWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace InventariumWebApp.Controllers
{
    public class ComputersController : Controller
    {
        private readonly IStringLocalizer<Shared> _localizer;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ComputersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IStringLocalizer<Shared> localizer)
        {
            _context = context;
            _userManager = userManager;
            _localizer = localizer;
        }

        private async Task<string?> GetTenantIdAsync()
        {
            {
                var user = await _userManager.GetUserAsync(User);
                return user?.TenantId;
            }
        }

        private async Task<CadPc?> GetComputerByIdAsync(int? id)
        {
            var tenantId = await GetTenantIdAsync();
            if (tenantId == null || id == null) return null;

            return await _context.Computers.FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);
        }


        // GET: Computers
        [Authorize(Roles = "Administrator, Default")]
        public async Task<IActionResult> Index()
        {
            ViewData["DataTableLanguage"] = new Dictionary<string, string>
            {
                ["lengthMenu"] = _localizer["DataTable_lengthMenu"],
                ["zeroRecords"] = _localizer["DataTable_zeroRecords"],
                ["info"] = _localizer["DataTable_info"],
                ["infoEmpty"] = _localizer["DataTable_infoEmpty"],
                ["infoFiltered"] = _localizer["DataTable_infoFiltered"],
                ["search"] = _localizer["DataTable_search"],
                ["paginateFirst"] = _localizer["DataTable_paginateFirst"],
                ["paginateLast"] = _localizer["DataTable_paginateLast"],
                ["paginateNext"] = _localizer["DataTable_paginateNext"],
                ["paginatePrevious"] = _localizer["DataTable_paginatePrevious"],
                ["colvis"] = _localizer["DataTable_colvis"]
            };


            var tenantId = (await GetTenantIdAsync())?.Trim();
            if (tenantId == null) return Unauthorized();

            var filtered = await _context.Computers.Where(c => c.TenantId == tenantId).ToListAsync();

            return View(filtered);

        }

        // GET: Computers/Details/5
        [Authorize(Roles = "Administrator,Default")]
        public async Task<IActionResult> Details(int? id)
        {
            var cadPc = await GetComputerByIdAsync(id);
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
