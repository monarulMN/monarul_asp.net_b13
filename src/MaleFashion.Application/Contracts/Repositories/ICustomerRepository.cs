using MaleFashion.Application.Features.Customers.Query;
using MaleFashion.Domain.Contracts;
using MaleFashion.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Contracts.Repositories
{
    public interface ICustomerRepository 
    {
        Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<(IList<UserDto>, int, int)> GetPagedCustomers(GetAllCustomersByPagingQuery query, 
            CancellationToken cancellationToken);
        Task<bool> IsEmailDuplicateAsync(string email, Guid id, CancellationToken cancellationToken);
        Task RemoveAsync(Guid id, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
        Task UpdateAsync(UserDto customer, CancellationToken cancellationToken);
    }
}
