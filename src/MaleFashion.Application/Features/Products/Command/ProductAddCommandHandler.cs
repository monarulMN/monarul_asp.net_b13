using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts;
using MaleFashion.Application.Exceptions;
using MaleFashion.Domain.Entities;
using MaleFashion.Domain.Utilities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Products.Command
{
    public class ProductAddCommandHandler : ICommandHandler<ProductAddCommand, Product>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductAddCommandHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Product> Handle(ProductAddCommand command, CancellationToken cancellationToken)
        {
            var isDuplicateName = await _unitOfWork.ProductRepository.IsDuplicateProductName(command.Name, cancellationToken);

            if (!isDuplicateName)
            {
                var product = _mapper.Map<Product>(command);
                product.Id = IdentityGenerator.NewSequentialGuid();                

                await _unitOfWork.ProductRepository.AddAsync(product, cancellationToken);

                if (!string.IsNullOrEmpty(command.ImageName))
                {
                    var productImage = new ProductImage
                    {
                        Id = IdentityGenerator.NewSequentialGuid(),
                        ProductId = product.Id,
                        ImageName = command.ImageName,
                        DisplayOrder = 1
                    };

                    await _unitOfWork.ProductImageRepository.AddAsync(productImage, cancellationToken);
                }

                await _unitOfWork.SaveAsync(cancellationToken);

                return product;
            }
            else
                throw new DuplicateDataException("Product name is duplicate!");
            
        }
    }
}
