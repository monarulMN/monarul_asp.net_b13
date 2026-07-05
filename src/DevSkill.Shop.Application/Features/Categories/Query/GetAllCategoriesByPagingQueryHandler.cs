using Cortex.Mediator.Queries;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Features.Categories.Query
{
    public class GetAllCategoriesByPagingQueryHandler : IQueryHandler<GetAllCategoriesByPagingQuery, 
        (IList<Category>, int, int)>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public GetAllCategoriesByPagingQueryHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public async Task<(IList<Category>, int, int)> Handle(GetAllCategoriesByPagingQuery query, 
            CancellationToken cancellationToken)
        {
            return await _applicationUnitOfWork.CategoryRepository.GetPagedCategories(query, cancellationToken);
        }
    }
}
