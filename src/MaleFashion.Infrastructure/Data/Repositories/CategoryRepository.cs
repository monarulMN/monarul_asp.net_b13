using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Application.Features.Categories.Query;
using MaleFashion.Application.Features.Products.Query;
using MaleFashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MaleFashion.Infrastructure.Data.Repositories
{
    public class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(IList<Category>, int, int)> GetPagedCategories(GetAllCategoriesByPagingQuery query, CancellationToken cancellationToken)
        {
            return await GetDynamicAsync(x => query.SearchText == null || x.Name.Contains(query.SearchText),
                query.SortText,
                null,
                query.PageIndex,
                query.PageSize,
                true,
                cancellationToken);
        }

        public async Task<bool> IsDuplicateCategoryName(string name, Guid? id, CancellationToken cancellationToken)
        {
            if(!id.HasValue)
            {
                return (await GetCountAsync(x => x.Name == name, cancellationToken)) > 0;
            }
            else
            {
                return (await GetCountAsync(x => x.Name == name && x.Id != id.Value, cancellationToken)) > 0;
            }
            
        }
    }
}
