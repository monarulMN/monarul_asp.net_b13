using Cortex.Mediator.Queries;
using MaleFashion.Application.Contracts;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.ProductImages.Query
{
    internal class GetAllProductImageByPagingQueryHandler : IQueryHandler<GetAllProductImageByPagingQuery, (IList<ProductImage>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetAllProductImageByPagingQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<ProductImage>, int, int)> Handle(GetAllProductImageByPagingQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductImageRepository.GetPagedProductImages(query, cancellationToken);
        }
    }
}
