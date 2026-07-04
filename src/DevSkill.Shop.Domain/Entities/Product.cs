using DevSkill.Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

namespace DevSkill.Shop.Domain.Entities
{
    public class Product : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }        
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public string? Brand { get; set; } 
        public string? Sku { get; set; } 
        public string? Color { get; set; } 
        public double Weight { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public Stock Stock { get; set; } = null!;
    }
}
