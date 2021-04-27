using BlazorStore.Areas.Identity.Pages.Account;
using BlazorStore.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace BlazorStore.Pages.Identity
{
    [AllowAnonymous]
    public partial class Register : ComponentBase
    {
        [Inject] public UserManager<IdentityUser> UserManager { get; set; }
        [Inject] public SignInManager<IdentityUser> SignInManager { get; set; }
        [Inject] public ILogger<Register> Logger { get; set; }
        [Inject] public IEmailSender EmailSender { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public RoleManager<IdentityRole> RoleManager { get; set; }
        [Parameter] public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public InputModel Input { get; set; } = new();
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [MaxLength(100)]
            public string LastName { get; set; }
            public string FirstName { get; set; }
            [Required]
            [MinLength(5), MaxLength(200)]
            public string Address { get; set; }
        }
        protected override async Task OnInitializedAsync()
        {
            //var Input = new InputModel() { Email = "blabla" };
            //  NavigationManager.NavigateTo($"/confirmregistration/{"blabla"}/{1}");
            // var callbackUrl = string.Format("{0}/Account/ConfirmEmail", NavigationManager.Uri);
            ExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        async Task Registration()
        {
            ReturnUrl = NavigationManager.BaseUri;
            ExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, LastName = Input.LastName, FirstName = Input.FirstName, Address = Input.Address };
            var result = await UserManager.CreateAsync(user, Input.Password);
            if (result.Succeeded)
            {
                if (!await RoleManager.RoleExistsAsync(StaticData.AdminRole))
                    await RoleManager.CreateAsync(new(StaticData.AdminRole));

                await UserManager.AddToRoleAsync(user, StaticData.AdminRole);

                Logger.LogInformation("User created a new account with password.");

                var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = string.Format("{0}/Account/ConfirmEmail/{1}/{2}", NavigationManager.Uri, user.Id, ReturnUrl);
                //Url.Page(
                //   "/Account/ConfirmEmail",
                //   pageHandler: null,
                //   values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                //   protocol: Request.Scheme);



                await EmailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                if (UserManager.Options.SignIn.RequireConfirmedAccount)
                {
                    NavigationManager.NavigateTo($"/confirmregistration/{Input.Email}");
                }
                else
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    NavigationManager.NavigateTo(ReturnUrl);
                }
            }
            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError(string.Empty, error.Description);
            //}

        }
    }
}
