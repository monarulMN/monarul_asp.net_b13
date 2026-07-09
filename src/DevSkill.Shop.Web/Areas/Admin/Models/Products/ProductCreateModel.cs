using System.ComponentModel.DataAnnotations;

namespace DevSkill.Shop.Web.Areas.Admin.Models.Products
{
    public class ProductCreateModel
    {
        public Guid Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [Range(0.00, 99999)]
        public double Price { get; set; }
        public bool IsActive { get; set; }

        [StringLength(200)]
        public string Brand { get; set; }

        [StringLength(200)]
        public string Sku { get; set; }

        [StringLength(200)]
        public string Color { get; set; }

        [Range(0.00, 99999)]
        public double Weight { get; set; }

    }
}
