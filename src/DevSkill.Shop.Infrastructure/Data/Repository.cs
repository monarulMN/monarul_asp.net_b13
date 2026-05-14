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
        private readonly DbContext _dbContext;
        private readonly DbSet<TAggregateRoot> _dbSet;

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
        public void Update(TAggregateRoot entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(TAggregateRoot entity)
        {
            _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
