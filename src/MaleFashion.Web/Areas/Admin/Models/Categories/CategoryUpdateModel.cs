using System.ComponentModel.DataAnnotations;

namespace MaleFashion.Web.Areas.Admin.Models.Categories
{
    public class CategoryUpdateModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength (100)]
        public string Name { get; set; }

        [Required]
        [StringLength (400)]
        public string Description { get; set; }

        [Display(Name ="Picture")]
        public IFormFile? Image { get; set; }

        public string? ImageUrl { get; set; }

    }
}
