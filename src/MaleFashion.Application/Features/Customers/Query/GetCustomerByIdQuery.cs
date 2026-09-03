using Cortex.Mediator.Queries;
using MaleFashion.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Customers.Query
{
    public class GetCustomerByIdQuery : IQuery<UserDto?>
    {
        public Guid Id { get; set; }
    }
}
