using MaleFashion.Application.Features.Products.Query;
using MaleFashion.Domain.Contracts;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Contracts.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<(IList<Product>, int, int)> GetPagedProducts(GetAllProductsByPagingQuery query, CancellationToken cancellationToken);
        Task<bool> IsDuplicateProductName(string name, CancellationToken cancellationToken);
    }
}
