using DevSkill.Shop.Application.Features.Products.Query;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Contracts
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<bool> CheckDuplicateProductName(string name, CancellationToken cancellationToken);
        Task<(IList<Product>, int, int)> GetPagedProducts(GetAllProductsByPagingQuery query, 
            CancellationToken cancellationToken);
    }
}
