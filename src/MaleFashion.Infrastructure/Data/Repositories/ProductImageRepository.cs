using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Application.Features.ProductImages.Query;
using MaleFashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Infrastructure.Data.Repositories
{
    public class ProductImageRepository : Repository<ProductImage, Guid>, IProductImageRepository
    {
        public ProductImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<ProductImage>> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Where(i => i.ProductId == productId)
                .OrderBy(i => i.DisplayOrder)
                .ToListAsync(cancellationToken);
        }

        
    }
}
