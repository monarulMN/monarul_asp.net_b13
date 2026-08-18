using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Infrastructure.Data.Repositories
{
    public class ProductSizeRepository : Repository<ProductSize, Guid>, IProductSizeRepository
    {
        public ProductSizeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
