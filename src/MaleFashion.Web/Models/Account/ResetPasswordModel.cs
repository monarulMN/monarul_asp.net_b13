using System.ComponentModel.DataAnnotations;

namespace MaleFashion.Web.Models.Account
{
    public class ResetPasswordModel
    {
        [Required]
        public string UserId { get; set; } = default!;

        [Required]
        public string Token { get; set; } = default!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = default!;

        
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = " Password")]        
        public string Password { get; set; } = default!;


        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm  password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }        
    }
}
