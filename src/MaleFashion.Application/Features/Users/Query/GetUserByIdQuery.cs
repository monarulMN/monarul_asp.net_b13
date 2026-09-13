using Cortex.Mediator.Queries;
using MaleFashion.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Users.Query
{
    public class GetUserByIdQuery : IQuery<UserDto?>
    {
        public Guid Id { get; set; }
    }
}
