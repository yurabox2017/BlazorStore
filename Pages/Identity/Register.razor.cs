using BlazorStore.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Pages.Identity
{
    public partial class Register : ComponentBase
    {
        [Inject] public UserManager<IdentityUser> UserManager { get; set; }
        [Inject] public SignInManager<IdentityUser> SignInManager { get; set; }
        [Inject] public ILogger<Register> Logger { get; set; }
        [Inject] public IEmailSender EmailSender { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public InputModel Input { get; set; }
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
    }
}
