using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Entities
{
    public class Product : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int StockQuantity { get; set; }
        public string? SKU { get; set; }
        public string MainImageUrl { get; set; } = null!;
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; } 
            = new List<ProductImage>();
    }
}
