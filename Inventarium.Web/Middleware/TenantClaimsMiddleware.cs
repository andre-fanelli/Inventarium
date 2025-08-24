using System.Security.Claims;
using System.Threading.Tasks;
using InventariumWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace InventariumWebApp.Middleware
{
    public class TenantClaimsMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantClaimsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                // Verifica se a claim TenantId já existe
                if (context.User.FindFirst("TenantId") == null)
                {
                    // Obtém o UserManager do serviço de escopo
                    var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();

                    // Obtém o usuário pelo name identifier 
                    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    if (!string.IsNullOrEmpty(userId))
                    {
                        var user = await userManager.FindByIdAsync(userId);
                        if (user != null && !string.IsNullOrEmpty(user.TenantId))
                        {
                            // Adiciona a claim para a identidade atual
                            var identity = (ClaimsIdentity)context.User.Identity;
                            identity.AddClaim(new Claim("TenantId", user.TenantId));

                            // Opcionalmente, também podemos salvar essa claim para futuras autenticações
                            await userManager.AddClaimAsync(user, new Claim("TenantId", user.TenantId));
                        }
                    }
                }
            }

            // Continua para o próximo middleware
            await _next(context);
        }
    }
}