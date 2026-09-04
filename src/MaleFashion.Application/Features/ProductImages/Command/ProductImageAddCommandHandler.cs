using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts;
using MaleFashion.Domain.Entities;
using MaleFashion.Domain.Utilities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.ProductImages.Command
{
    public class ProductImageAddCommandHandler : ICommandHandler<ProductImageAddCommand, ProductImage>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public ProductImageAddCommandHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductImage> Handle(ProductImageAddCommand command, CancellationToken cancellationToken)
        {
            var productImage = _mapper.Map<ProductImage>(command);
            productImage.Id = IdentityGenerator.NewSequentialGuid();

            await _unitOfWork.ProductImageRepository.AddAsync(productImage, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return productImage;
        }
    }
}
