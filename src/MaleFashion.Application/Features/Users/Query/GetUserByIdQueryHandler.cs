using Cortex.Mediator.Queries;
using MaleFashion.Application.Contracts;
using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Users.Query
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByIdAsync(query.Id, cancellationToken);
        }
    }
}
