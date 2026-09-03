using System.ComponentModel.DataAnnotations;

namespace MaleFashion.Web.Areas.Admin.Models.Categories
{
    public class CategoryCreateModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(400)]
        public string Description { get; set; } 

        [Display(Name = "Picture")]
        public IFormFile Image { get; set; } = null!;
        
    }
}
