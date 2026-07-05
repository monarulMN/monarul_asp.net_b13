using Cortex.Mediator.Commands;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Domain.Utilities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Features.Categories.Command
{
    public class CategoryAddCommandHandler : ICommandHandler<CategoryAddCommand, Category>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryAddCommandHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Category> Handle(CategoryAddCommand command, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(command);
            category.Id = IdentityGenerator.NewSequentialGuid();

            await _unitOfWork.CategoryRepository.AddAsync(category, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return category;
        }
    }
}
