using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts;
using MaleFashion.Application.Exceptions;
using MaleFashion.Domain.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Categories.Command
{
    public class CategoryUpdateCommandHandler : ICommandHandler<CategoryUpdateCommand, Category>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryUpdateCommandHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Category> Handle(CategoryUpdateCommand command, CancellationToken cancellationToken)
        {
            var isDuplicateName = await _unitOfWork.CategoryRepository.IsDuplicateCategoryName(command.Name, 
                command.Id, cancellationToken);

            if (!isDuplicateName)
            {
                var category =  _unitOfWork.CategoryRepository.GetById(command.Id);
                category = _mapper.Map(command, category);


                await _unitOfWork.CategoryRepository.EditAsync(category, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);

                return category;

            }
            else            
                throw new DuplicateDataException("Category name is duplicate.");
         }
    }
}
