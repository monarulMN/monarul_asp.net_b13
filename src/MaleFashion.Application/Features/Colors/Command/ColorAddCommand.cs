using Cortex.Mediator.Commands;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MaleFashion.Application.Features.Colors.Command
{
    public class ColorAddCommand : ICommand<Color>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }

    }
}
