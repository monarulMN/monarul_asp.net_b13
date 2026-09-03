using Cortex.Mediator.Queries;
using MaleFashion.Application.Contracts;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Categories.Query
{
    public class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, Category?>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetCustomerByIdQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category?> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CategoryRepository.GetByIdAsync(query.Id, cancellationToken);
        }
    }
}
