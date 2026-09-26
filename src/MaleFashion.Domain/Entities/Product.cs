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
        public double Price { get; set; }
        public double? DiscountPrice { get; set; }
        public int StockQuantity { get; set; }
        public string? SKU { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
            = new List<ProductImage>();

        //public ICollection<CartItem> CartItems { get; set; }
        //    = new List<CartItem>();

        //public ICollection<OrderItem> OrderItems { get; set; }
        //    = new List<OrderItem>();

        //public ICollection<WishListItem> WishlistItems { get; set; }
        //    = new List<WishListItem>();

        //public ICollection<Review> Reviews { get; set; }
        //    = new List<Review>();

    }
}
