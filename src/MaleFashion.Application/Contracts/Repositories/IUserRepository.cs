using MaleFashion.Application.Features.Users.Query;
using MaleFashion.Domain.Contracts;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Contracts.Repositories
{
    public interface IUserRepository 
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<(IList<User>, int, int)> GetPagedUsersAsync(GetAllUsersByPagingQuery query, 
            CancellationToken cancellationToken);
        Task<bool> IsEmailDuplicateAsync(string email, Guid id, CancellationToken cancellationToken);
        Task RemoveAsync(Guid id, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
        Task UpdateAsync(User user, CancellationToken cancellationToken);
    }
}
