using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Application.Features.Categories.Query;
using MaleFashion.Application.Features.Customers.Query;
using MaleFashion.Domain.DTOs;
using MaleFashion.Domain.Entities;
using MaleFashion.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MapsterMapper;

namespace MaleFashion.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerRepository(ApplicationUserManager userManager, 
            ApplicationDbContext dbContext,
            IMapper mapper) 
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return null;

            return _mapper.Map<UserDto>(user);
        }


        public async Task<(IList<UserDto>, int, int)> GetPagedCustomers(GetAllCustomersByPagingQuery query,
            CancellationToken cancellationToken)
        {
            var user = _userManager.Users.AsQueryable();

            if(!string.IsNullOrEmpty(query.SearchText))
            {
                user = user.Where(x => 
                        (x.FirstName != null && x.FirstName.Contains(query.SearchText)) || 
                        (x.LastName != null && x.LastName.Contains(query.SearchText)) || 
                        (x.Email != null && x.Email.Contains(query.SearchText)) || 
                        (x.PhoneNumber != null && x.PhoneNumber.Contains(query.SearchText))
                    );
            }

            int totalCount = await user.CountAsync(cancellationToken);

            var users = await user
                .Take(query.PageSize)
                .Select(u => _mapper.Map<UserDto>(u))
                .ToListAsync(cancellationToken);
                        

            return (users, totalCount, query.PageSize);
        }

        public async Task<bool> IsEmailDuplicateAsync(string email, Guid id, CancellationToken cancellationToken)
        {
            if(!id.Equals(Guid.Empty))
            {
                return await _userManager.Users.AnyAsync(x => x.Email == email && x.Id != id, cancellationToken);
            }
            else
            {
                return await _userManager.Users.AnyAsync(x => x.Email == email, cancellationToken);
            }
        }


        public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }


        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }


        public async Task UpdateAsync(UserDto customer, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(customer.Id.ToString());

            if (user == null)
            {
                throw new InvalidOperationException("Customer not found");
            }

            _mapper.Map(customer, user);
            await _userManager.UpdateAsync(user);
        }
    }
}
