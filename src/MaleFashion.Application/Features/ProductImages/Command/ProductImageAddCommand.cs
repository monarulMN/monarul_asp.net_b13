
using Cortex.Mediator.Commands;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MaleFashion.Application.Features.ProductImages.Command
{
    public class ProductImageAddCommand : ICommand<ProductImage>
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public int DisplayOrder { get; set; }

        public Guid ProductId { get; set; }
        
    }
}
