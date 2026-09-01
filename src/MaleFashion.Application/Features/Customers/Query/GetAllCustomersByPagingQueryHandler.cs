using Cortex.Mediator.Queries;
using MaleFashion.Application.Contracts;
using MaleFashion.Domain.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Customers.Query
{
    public class GetAllCustomersByPagingQueryHandler : IQueryHandler<GetAllCustomersByPagingQuery, (IList<User>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCustomersByPagingQueryHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<(IList<User>, int, int)> Handle(GetAllCustomersByPagingQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserRepository.GetPagedCustomers(query, cancellationToken);
        }
    }
}
