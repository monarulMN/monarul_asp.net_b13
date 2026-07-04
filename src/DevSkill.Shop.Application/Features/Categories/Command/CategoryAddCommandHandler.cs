using Cortex.Mediator.Commands;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Features.Categories.Command
{
    public class CategoryAddCommandHandler : ICommandHandler<CategoryAddCommand, Category>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public CategoryAddCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Category> Handle(CategoryAddCommand command, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = command.Id,
                Name = command.Name,
                IsActive = command.IsActive,
                ImageName = command.ImageName
            };

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveAsync();

            return category;
        }
    }
}
