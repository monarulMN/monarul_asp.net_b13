using Cortex.Mediator.Commands;
using DevSkill.Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DevSkill.Shop.Application.Features.Categories.Command
{
    public class CategoryAddCommand : ICommand<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public bool IsActive { get; set; }
        public string ImageName { get; set; } 
    }
}
