using MaleFashion.Application.Features.Categories.Query;
using MaleFashion.Application.Features.Products.Query;
using MaleFashion.Domain.Contracts;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Contracts.Repositories
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        Task<(IList<Category>, int, int)> GetPagedCategories(GetAllCategoriesByPagingQuery query, CancellationToken cancellationToken);
        Task<bool> IsDuplicateCategoryName(string name, Guid? id, CancellationToken cancellationToken);
    }
}
