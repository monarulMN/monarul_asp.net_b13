using Cortex.Mediator.Commands;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MaleFashion.Application.Features.Categories.Command
{
    public class CategoryDeleteCommand : ICommand<Category>
    {
        public Guid Id { get; set; }
    }
}
