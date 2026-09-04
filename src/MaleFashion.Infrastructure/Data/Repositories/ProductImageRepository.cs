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

        public async Task<(IList<ProductImage>, int, int)> GetPagedProductImages(GetAllProductImageByPagingQuery query, 
            CancellationToken cancellationToken)
        {
            return await 
        }
    }
}
