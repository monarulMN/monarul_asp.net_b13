using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Application.Features.Customers.Query;
using MaleFashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<CustomerDto, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(IList<CustomerDto>, int, int)> GetPagedCustomers(GetAllCustomersByPagingQuery query,
            CancellationToken cancellationToken)
        {
            return await GetDynamicAsync(x => query.SearchText == null || x.FirstName.Contains(query.SearchText),
                query.SortText,
                null,
                query.PageIndex,
                query.PageSize,
                true,
                cancellationToken);
        }
    }
}
