using Cortex.Mediator.Queries;
using MaleFashion.Application.Contracts;
using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Users.Query
{
    public class GetAllUsersByPagingQueryHandler : IQueryHandler<GetAllUsersByPagingQuery, (IList<User>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetAllUsersByPagingQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<(IList<User>, int, int)> Handle(GetAllUsersByPagingQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserRepository.GetPagedUsersAsync(query, cancellationToken);
        }
    }
}
