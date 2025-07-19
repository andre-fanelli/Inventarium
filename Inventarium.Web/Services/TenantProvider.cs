using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Inventarium.Web.Services
{
    public interface ITenantProvider
    {
        string GetTenantId();
    }

    public interface ITenantEntity
    {
        string TenantId { get; set; }
    }

    // Implementação modificada para não depender do UserManager
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TenantProvider> _logger;

        public TenantProvider(
            IHttpContextAccessor httpContextAccessor,
            ILogger<TenantProvider> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public string GetTenantId()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            // Verifica se há um usuário autenticado
            if (httpContext?.User?.Identity?.IsAuthenticated != true)
            {
                _logger.LogWarning("Tentativa de acessar TenantId sem usuário autenticado");
                throw new InvalidOperationException("Usuário não está autenticado. Não é possível determinar o TenantId.");
            }

            // Tenta obter TenantId das claims
            var tenantId = httpContext.User.FindFirst("TenantId")?.Value;

            if (string.IsNullOrEmpty(tenantId))
            {
                _logger.LogError("TenantId não encontrado nas Claims do usuário logado");
                throw new InvalidOperationException("TenantId não encontrado nas Claims do usuário logado.");
            }

            return tenantId;
        }
    }
}