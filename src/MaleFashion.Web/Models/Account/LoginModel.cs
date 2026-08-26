using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace MaleFashion.Web.Models.Account
{
    public class LoginModel
    {
        [Required (ErrorMessage ="Email is required.")]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage ="Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public IList<AuthenticationScheme>? ExternalLogins { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
