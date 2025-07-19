using System.ComponentModel.DataAnnotations;

namespace InventariumWebApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Empresa")]
        public string Company { get; set; }

        [Phone]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Senha")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Perfil")]
        public string Role { get; set; }
    }
}
