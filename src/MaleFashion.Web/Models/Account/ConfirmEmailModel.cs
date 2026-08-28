using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MaleFashion.Web.Models.Account
{
    public class ConfirmEmailModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; } = default!;
    }
}
