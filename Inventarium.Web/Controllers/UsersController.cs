using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using InventariumWebApp.Models;
using System.Threading.Tasks;

namespace InventariumWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            // Obtém o usuário logado
            var currentUser = _userManager.GetUserAsync(User).Result;

            // Filtra os usuários com base no TenantId do usuário logado
            var tenantId = currentUser.TenantId;

            // Carrega os usuários que pertencem ao mesmo TenantId
            var users = _userManager.Users.Where(u => u.TenantId == tenantId).ToList();

            // Retorna a lista de usuários filtrada para a visão
            return View(users);
        } 

        public async Task<IActionResult> Create()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var model = new RegisterViewModel
            {
                Company = currentUser?.Company
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Pega o TenantId do usuário logado
                var currentUser = await _userManager.GetUserAsync(User);
                
                var user = new ApplicationUser
                {
                    UserName = model.Email, 
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Company = currentUser.Company,
                    PhoneNumber = model.PhoneNumber,
                    TenantId = currentUser.TenantId 
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    TempData["SuccessCreateMessage"] = "Usuario criado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromBody] DeleteUserDto data)
        {
            var user = await _userManager.FindByIdAsync(data.Id);
            if (user == null)
            {
                return Json(new { success = false, message = "Usuário não encontrado." });
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Json(new { success = true });
            }
            else
            {
                var errorMessages = string.Join(" | ", result.Errors.Select(e => e.Description));
                return Json(new { success = false, message = "Erro ao excluir o usuário." });
            }
        }
        public class DeleteUserDto
        {
            public string Id { get; set; }
        }
    }
}

