using Microsoft.AspNetCore.Identity;

namespace InventariumWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string TenantId { get; set; }  // Adiciona o TenantId
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
    }
}

