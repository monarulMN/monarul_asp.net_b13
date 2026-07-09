using Cortex.Mediator.Commands;
using DevSkill.Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Features.Products.Command
{
    public class ProductAddCommand : ICommand<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public string? Brand { get; set; }
        public string? Sku { get; set; }
        public string? Color { get; set; }
        public double Weight { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
