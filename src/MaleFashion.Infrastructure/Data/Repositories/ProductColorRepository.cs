using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Infrastructure.Data.Repositories
{
    public class ProductColorRepository : Repository<ProductColor, Guid>, IProductColorRepository
    {
        public ProductColorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
