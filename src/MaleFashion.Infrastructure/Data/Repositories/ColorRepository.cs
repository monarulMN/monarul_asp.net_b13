using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Application.Features.Colors.Query;
using MaleFashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Infrastructure.Data.Repositories
{
    public class ColorRepository : Repository<Color, Guid>, IColorRepository
    {
        public ColorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(IList<Color>, int, int)> GetPagedColors(GetAllColorByPagingQuery query, CancellationToken cancellationToken)
        {
            return await GetDynamicAsync(x => query.SearchText == null || x.Name.Contains(query.SearchText),
                query.SortText,
                null,
                query.PageIndex,
                query.PageSize,
                true,
                cancellationToken);
        }

        public async Task<bool> IsDuplicateColorName(string name, Guid? id, CancellationToken cancellationToken)
        {
            if (!id.HasValue)
            {
                return (await GetCountAsync(x => x.Name == name, cancellationToken)) > 0;
            }
            else
            {
                return (await GetCountAsync(x => x.Name == name && x.Id != id.Value, cancellationToken)) > 0;
            }
        }
    }
}
