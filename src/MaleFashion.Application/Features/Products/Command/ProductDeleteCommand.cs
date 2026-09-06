using Cortex.Mediator.Commands;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace MaleFashion.Application.Features.Products.Command
{
    public class ProductDeleteCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
