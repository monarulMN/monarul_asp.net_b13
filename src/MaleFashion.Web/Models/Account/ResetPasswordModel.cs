using System.ComponentModel.DataAnnotations;

namespace MaleFashion.Web.Models.Account
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = default!;


        [Required(ErrorMessage = "Password is required.")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string NewPassword { get; set; } = default!;


        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New password")]        
        public string? ConfirmNewPassword { get; set; }

        [Required]
        public string Code { get; set; } = default!;
    }
}
