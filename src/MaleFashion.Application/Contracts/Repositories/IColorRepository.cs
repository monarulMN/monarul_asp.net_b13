using MaleFashion.Application.Features.Colors.Query;
using MaleFashion.Domain.Contracts;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;

using System.Text;

namespace MaleFashion.Application.Contracts.Repositories
{
    public interface IColorRepository : IRepository<Color, Guid>
    {
        Task<(IList<Color>, int, int)> GetPagedColors(GetAllColorByPagingQuery query, CancellationToken cancellationToken);
        Task<bool> IsDuplicateColorName(string name, Guid? id, CancellationToken cancellationToken);
    }
}
