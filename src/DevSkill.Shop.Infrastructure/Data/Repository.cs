using DevSkill.Shop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Infrastructure.Data
{
    public class Repository<TAggregateRoot, TKey> : IRepository<TAggregateRoot, TKey>, IDisposable
        where TAggregateRoot : class, IAggregateRoot<TKey>
        where TKey : IComparable
    {
        private DbContext _dbContext;
        private DbSet<TAggregateRoot> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TAggregateRoot>();
        }
        public void Add(TAggregateRoot entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(TAggregateRoot entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
