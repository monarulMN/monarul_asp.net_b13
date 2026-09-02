using Cortex.Mediator.Commands;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace MaleFashion.Application.Features.Categories.Command
{
    public class CategoryDeleteCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
