using Cortex.Mediator.Queries;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Features.Categories.Query
{
    public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Category?>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        public GetProductByIdQueryHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }
        public async Task<Category?> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return await _applicationUnitOfWork.CategoryRepository.GetByIdAsync(query.Id, cancellationToken);
        }
    }
}
