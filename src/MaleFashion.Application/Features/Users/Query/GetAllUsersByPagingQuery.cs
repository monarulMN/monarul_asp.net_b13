using Cortex.Mediator.Queries;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Users.Query
{
    public class GetAllUsersByPagingQuery : IQuery<(IList<User>, int, int)>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? SearchText { get; set; }
        public string? SortText { get; set; }
    }
}
