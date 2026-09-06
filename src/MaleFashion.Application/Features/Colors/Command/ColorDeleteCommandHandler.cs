using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Colors.Command
{
    public class ColorDeleteCommandHandler : ICommandHandler<ColorDeleteCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public ColorDeleteCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ColorDeleteCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.ColorRepository.RemoveAsync(command.Id, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
