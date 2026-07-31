using DevSkill.Shop.Application.Features.Categories.Query;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Contracts
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        Task<bool> CheckDuplicateCategoryName(string name, Guid? id, CancellationToken cancellationToken);
        Task<(IList<Category>, int, int)> GetPagedCategories(GetAllCategoriesByPagingQuery query, 
            CancellationToken cancellationToken);
    }
}
