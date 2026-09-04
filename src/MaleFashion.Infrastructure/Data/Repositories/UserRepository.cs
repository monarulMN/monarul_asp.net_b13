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

        
    }
}
