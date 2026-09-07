using MaleFashion.Application.Features.ProductImages.Query;
using MaleFashion.Domain.Contracts;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Contracts.Repositories
{
    public interface IProductImageRepository : IRepository<ProductImage, Guid>
    {
        Task<IList<ProductImage>> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);
        
    }
}
