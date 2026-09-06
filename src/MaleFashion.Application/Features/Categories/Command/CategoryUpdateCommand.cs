using Cortex.Mediator.Commands;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MaleFashion.Application.Features.Categories.Command
{
    public class CategoryUpdateCommand : ICommand<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string ImageUrl { get; set; }

    }
}
