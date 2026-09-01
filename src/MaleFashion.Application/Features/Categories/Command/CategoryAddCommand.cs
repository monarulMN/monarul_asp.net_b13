using Cortex.Mediator.Commands;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MaleFashion.Application.Features.Categories.Command
{
    public class CategoryAddCommand : ICommand<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string ImageUrl { get; set; } 
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
