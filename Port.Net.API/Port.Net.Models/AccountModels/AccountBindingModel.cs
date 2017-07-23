using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Port.Net.Models.AccountModels
{
    public class AccountBindingModel
    {
        public class AddExternalLoginBindingModel
        {
            [Microsoft.Build.Framework.Required]
            [Display(Name = "External access token")]
            public string ExternalAccessToken { get; set; }
        }

        public class ChangePasswordBindingModel
        {
            [Microsoft.Build.Framework.Required]
            [DataType(DataType.Password)]
            [Display(Name = "Current password")]
            public string OldPassword { get; set; }

            [Microsoft.Build.Framework.Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public class RegisterBindingModel
        {
            [Microsoft.Build.Framework.Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Microsoft.Build.Framework.Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public class RegisterExternalBindingModel
        {
            [Microsoft.Build.Framework.Required]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public class RemoveLoginBindingModel
        {
            [Microsoft.Build.Framework.Required]
            [Display(Name = "Login provider")]
            public string LoginProvider { get; set; }

            [Microsoft.Build.Framework.Required]
            [Display(Name = "Provider key")]
            public string ProviderKey { get; set; }
        }

        public class SetPasswordBindingModel
        {
            [Microsoft.Build.Framework.Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
    }
}
