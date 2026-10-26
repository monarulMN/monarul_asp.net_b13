using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Application.Features.Categories.Query;
using MaleFashion.Application.Features.Users.Query;
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
using MaleFashion.Application.Contracts;

namespace MaleFashion.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IServerTime _serverTime;

        public UserRepository(ApplicationDbContext dbContext,
            IMapper mapper,
            IServerTime serverTime) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _serverTime = serverTime;
        }


        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return null;

            return _mapper.Map<User>(user);
        }


        public async Task<(IList<User>, int, int)> GetPagedUsersAsync(GetAllUsersByPagingQuery query,
            CancellationToken cancellationToken)
        {

            var user = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(query.SearchText))
            {
                user = user.Where(x =>
                        (x.UserName != null && x.UserName.Contains(query.SearchText)) ||
                        (x.Email != null && x.Email.Contains(query.SearchText)) 
                    );
            }

            int totalCount = await user.CountAsync(cancellationToken);

            var users = await user
                .Take(query.PageSize)
                .Select(u => _mapper.Map<User>(u))
                .ToListAsync(cancellationToken);


            return (users, totalCount, query.PageSize);
        }

        public async Task<bool> IsEmailDuplicateAsync(string email, Guid id, CancellationToken cancellationToken)
        {
            if(!id.Equals(Guid.Empty))
            {
                return await _dbContext.Users.AnyAsync(x => x.Email == email && x.Id != id, cancellationToken);
            }
            else
            {
                return await _dbContext.Users.AnyAsync(x => x.Email == email, cancellationToken);
            }
        }


        public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _dbContext.FindByIdAsync(id.ToString());
            if (user != null)
            {
                await _dbContext.DeleteAsync(user);
            }
        }


        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }


        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var users = await _dbContext.FindByIdAsync(user.Id.ToString());

            if (users == null)
            {
                throw new InvalidOperationException("User not found");
            }

            _mapper.Map(user, users);
            await _userManager.UpdateAsync(users);
        }
    }
}
