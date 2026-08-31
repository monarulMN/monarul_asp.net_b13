using System.ComponentModel.DataAnnotations;

namespace MaleFashion.Web.Areas.Admin.Models.Products
{
    public class ProductCreateModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, 999999)]
        public double Price { get; set; }
    }
}
