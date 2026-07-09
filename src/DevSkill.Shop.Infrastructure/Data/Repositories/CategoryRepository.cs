using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Application.Features.Categories.Query;
using DevSkill.Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Infrastructure.Data.Repositories
{
    public class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(IList<Category>, int, int)> GetPagedCategories(GetAllCategoriesByPagingQuery query, 
            CancellationToken cancellationToken)
        {
            return await GetDynamicAsync(x => query.SearchText == null || x.Name.Contains(query.SearchText), 
                query.SortText, 
                null, 
                query.PageIndex, 
                query.PageSize, 
                true, 
                cancellationToken);
        }

        public async Task<bool> CheckDuplicateCategoryName(string name, CancellationToken cancellationToken)
        {
            return (await GetCountAsync(x => x.Name == name, cancellationToken)) > 0;
        }
    }
}
