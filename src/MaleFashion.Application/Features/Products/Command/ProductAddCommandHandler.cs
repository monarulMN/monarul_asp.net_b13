using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts;
using MaleFashion.Domain.Entities;
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

            var product = new Product
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                DiscountPrice= command.DiscountPrice
            };
            await _unitOfWork.ProductRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return product;
        }
    }
}
