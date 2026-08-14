using System.Linq.Expressions;

namespace MaleFashion.Domain.Contracts
{
    public interface IRepository<TAggregateRoot, TKey>
        where TAggregateRoot : class, IAggregateRoot<TKey>
        where TKey : IComparable
    {
        void Add(TAggregateRoot entity);
        Task AddAsync(TAggregateRoot entity, CancellationToken cancellationToken);
    }
}
