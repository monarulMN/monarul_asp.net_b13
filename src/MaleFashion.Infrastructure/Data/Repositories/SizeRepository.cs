using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Infrastructure.Data.Repositories
{
    public class SizeRepository : Repository<Size, Guid>, ISizeRepository
    {
        public SizeRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            
        }
    }
}
