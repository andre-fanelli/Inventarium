// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using InventariumWebApp.Models;
using System.Security.Claims;

namespace InventariumWebApp.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Continuar conectado?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/Dashboard");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // Buscar o usuário pelo email antes do login
                var user = await _userManager.FindByEmailAsync(Input.Email);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }

                // Verificar se o TenantId está configurado para o usuário
                if (string.IsNullOrEmpty(user.TenantId))
                {
                    _logger.LogWarning("Login attempt failed: TenantId não está atribuído ao usuário {Email}.", Input.Email);
                    ModelState.AddModelError(string.Empty, "Conta de usuário não configurada corretamente. Entre em contato com o suporte.");
                    return Page();
                }

                // Tentar login
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");

                    // Verificar se o usuário já possui a claim TenantId
                    var existingClaims = await _userManager.GetClaimsAsync(user);
                    var tenantClaim = existingClaims.FirstOrDefault(c => c.Type == "TenantId");

                    // Se não tiver a claim ou se ela estiver diferente, atualiza
                    if (tenantClaim == null)
                    {
                        await _userManager.AddClaimAsync(user, new Claim("TenantId", user.TenantId));
                        // É necessário fazer logout e login novamente para atualizar as claims
                        await _signInManager.SignOutAsync();
                        await _signInManager.SignInAsync(user, Input.RememberMe);
                    }
                    else if (tenantClaim.Value != user.TenantId)
                    {
                        await _userManager.RemoveClaimAsync(user, tenantClaim);
                        await _userManager.AddClaimAsync(user, new Claim("TenantId", user.TenantId));
                        // É necessário fazer logout e login novamente para atualizar as claims
                        await _signInManager.SignOutAsync();
                        await _signInManager.SignInAsync(user, Input.RememberMe);
                    }

                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }
            return Page();
        }
    }
}
