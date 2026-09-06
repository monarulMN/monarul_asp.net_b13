using Cortex.Mediator.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Colors.Command
{
    public class ColorDeleteCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
