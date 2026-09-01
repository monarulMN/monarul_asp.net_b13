using Cortex.Mediator.Commands;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MaleFashion.Application.Features.Products.Command
{
    public class ProductAddCommand : ICommand<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public double? DiscountPrice { get; set; }
        public int StockQuantity { get; set; }
        public string? SKU { get; set; }
        //public string MainImageUrl { get; set; } = null!;
        //public bool IsFeatured { get; set; }
        //public bool IsActive { get; set; }
        //public DateTime CreatedDate { get; set; }
    }
}
