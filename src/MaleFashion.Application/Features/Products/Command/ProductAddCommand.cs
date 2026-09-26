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
        public string Name { get; set; } 
        public string Description { get; set; } 
        public double Price { get; set; }
        public double? DiscountPrice { get; set; }
        public int StockQuantity { get; set; } = 0;
        public string? SKU { get; set; }
        public string Color { get; set; } 
        public String Size { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        public string? ImageName { get; set; }
    }
}
