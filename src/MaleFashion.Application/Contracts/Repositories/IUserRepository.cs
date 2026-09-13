using MaleFashion.Application.Features.Users.Query;
using MaleFashion.Domain.Contracts;
using MaleFashion.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Contracts.Repositories
{
    public interface IUserRepository 
    {
        Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<(IList<UserDto>, int, int)> GetPagedUsers(GetAllUsersByPagingQuery query, 
            CancellationToken cancellationToken);
        Task<bool> IsEmailDuplicateAsync(string email, Guid id, CancellationToken cancellationToken);
        Task RemoveAsync(Guid id, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
        Task UpdateAsync(UserDto user, CancellationToken cancellationToken);
    }
}
