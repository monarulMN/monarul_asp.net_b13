using Cortex.Mediator.Queries;
using MaleFashion.Application.Contracts;
using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.DTOs;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Customers.Query
{
    public class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, UserDto?>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<UserDto?> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetByIdAsync(query.Id, cancellationToken);
        }
    }
}
