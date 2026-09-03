using Cortex.Mediator.Queries;
using MaleFashion.Application.Contracts;
using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.DTOs;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Customers.Query
{
    public class GetAllCustomersByPagingQueryHandler : IQueryHandler<GetAllCustomersByPagingQuery, (IList<UserDto>, int, int)>
    {
        private readonly ICustomerRepository _customerRepository;        
        private readonly IMapper _mapper;

        public GetAllCustomersByPagingQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<(IList<UserDto>, int, int)> Handle(GetAllCustomersByPagingQuery query, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetPagedCustomers(query, cancellationToken);
        }
    }
}
