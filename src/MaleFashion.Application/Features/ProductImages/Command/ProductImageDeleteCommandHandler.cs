using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.ProductImages.Command
{
    public class ProductImageDeleteCommandHandler : ICommandHandler<ProductImageDeleteCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public ProductImageDeleteCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(ProductImageDeleteCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.ProductImageRepository.RemoveAsync(command.Id, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

        }
    }
}
