using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventariumWebApp.BuildScript;
using Microsoft.AspNetCore.SignalR;

namespace InventariumWebApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BuildController : Controller
    {
        private readonly IHubContext<BuildHub> _hubContext;

        public BuildController(IHubContext<BuildHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Generate()
        {
            var tenantId = User.FindFirst("TenantId")?.Value;
            var email = User.Identity?.Name;

            // Verifica se o TenantId está presente
            if (string.IsNullOrEmpty(tenantId))
                return BadRequest("TenantId inválido.");

            // Chama o método para gerar o executável
            var downloadUrl = await BuildHelper.BuildExecutableAsync(tenantId, email, _hubContext);

            // Retorna o URL do executável gerado
            return Json(new { success = true, url = downloadUrl });
        }
    }
}
