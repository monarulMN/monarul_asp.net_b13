using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Infrastructure.Data.Repositories
{
    public class ProductVariantRepository : Repository<ProductVariant, Guid>, IProductVariantRepository
    {
        public ProductVariantRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
