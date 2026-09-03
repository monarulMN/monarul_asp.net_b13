using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Categories.Command
{
    public class CustomerDeleteCommandHandler : ICommandHandler<CustomerDeleteCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public CustomerDeleteCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CustomerDeleteCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.CategoryRepository.RemoveAsync(command.Id, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
