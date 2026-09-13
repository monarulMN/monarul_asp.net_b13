using Cortex.Mediator.Queries;
using MaleFashion.Application.Contracts;
using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Application.DTOs;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Users.Query
{
    public class GetAllUsersByPagingQueryHandler : IQueryHandler<GetAllUsersByPagingQuery, (IList<UserDto>, int, int)>
    {
        private readonly IUserRepository _userRepository;        
        private readonly IMapper _mapper;

        public GetAllUsersByPagingQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<(IList<UserDto>, int, int)> Handle(GetAllUsersByPagingQuery query, CancellationToken cancellationToken)
        {
            return await _userRepository.GetPagedUsers(query, cancellationToken);
        }
    }
}
