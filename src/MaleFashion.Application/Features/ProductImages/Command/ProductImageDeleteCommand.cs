using Cortex.Mediator.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.ProductImages.Command
{
    public class ProductImageDeleteCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
