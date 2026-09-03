using System.ComponentModel.DataAnnotations;

namespace MaleFashion.Web.Areas.Admin.Models.Customers
{
    public class CustomerUpdateModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
