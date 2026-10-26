using Cortex.Mediator.Queries;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Users.Query
{
    public class GetUserByIdQuery : IQuery<User?>
    {
        public Guid Id { get; set; }
    }
}
