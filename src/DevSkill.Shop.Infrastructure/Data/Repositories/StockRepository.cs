using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Infrastructure.Data.Repositories
{
    public class StockRepository : Repository<Stock, Guid>, IStockRepository
    {
        public StockRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
