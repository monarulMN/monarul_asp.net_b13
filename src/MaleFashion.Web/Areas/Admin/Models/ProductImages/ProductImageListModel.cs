using MaleFashion.Domain.Entities;

namespace MaleFashion.Web.Areas.Admin.Models.ProductImages
{
    public class ProductImageListModel
    {
        public Guid ProductId { get; set; }
        public string? ProductName  { get; set; }
        public IList<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
