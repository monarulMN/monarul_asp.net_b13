using MaleFashion.Application.Contracts.Repositories;

using MaleFashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        //public async Task<(IList<User>, int, int)> GetPagedCustomers(GetAllCustomertsByPagingQuery query, 
        //    CancellationToken cancellationToken)
        //{
        //    return await GetDynamicAsync(x =>query.SearchText == null || x.Name.Contains(query.SearchText),
        //        query.SortText,
        //        null,
        //        query.PageIndex,
        //        query.PageSize,
        //        true,
        //        cancellationToken);
        //}
    }
}
