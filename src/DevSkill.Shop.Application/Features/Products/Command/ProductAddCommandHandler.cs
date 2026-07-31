using Cortex.Mediator.Commands;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Application.Exceptions;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Domain.Interfaces;
using DevSkill.Shop.Domain.Utilities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Features.Products.Command
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
            var isDuplicateName = await _unitOfWork.ProductRepository.CheckDuplicateProductName(command.Name, null,
                cancellationToken);

            if (!isDuplicateName)
            {
                var product = _mapper.Map<Product>(command);
                product.Id = IdentityGenerator.NewSequentialGuid();
                

                await _unitOfWork.ProductRepository.AddAsync(product, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);

                return product;
            }
            else
            {
                throw new DuplicateDataException($"Product with name is Duplicate.");
            }
        }
    }
}
