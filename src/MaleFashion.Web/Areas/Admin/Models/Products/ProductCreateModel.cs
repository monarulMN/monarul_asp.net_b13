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
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0, 999999)]
        public double Price { get; set; }

        [Required]
        [Range(0, 100)]
        public double? DiscountPrice { get; set; }

        [Required]
        [Range(0, 999999)]
        public int StockQuantity { get; set; }

        [Required]
        [StringLength(50)]
        public string? SKU { get; set; }
    }
}
