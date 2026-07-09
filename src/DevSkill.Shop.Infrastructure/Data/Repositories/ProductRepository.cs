using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Application.Features.Products.Query;
using DevSkill.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Infrastructure.Data.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(IList<Product>, int, int)> GetPagedProducts(GetAllProductsByPagingQuery query, 
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

        public async Task<bool> CheckDuplicateProductName(string name, CancellationToken cancellationToken)
        {
            return (await GetCountAsync(x => x.Name == name, cancellationToken)) > 0;
        }
    }
}
