using System.ComponentModel.DataAnnotations;

namespace MaleFashion.Web.Areas.Admin.Models.Categories
{
    public class CategoryCreateModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Display(Name = "Picture")]
        public IFormFile Image { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
