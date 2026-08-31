using Cortex.Mediator.Queries;
using MaleFashion.Application.Contracts;
using MaleFashion.Domain.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Products.Query
{
    public class GetAllProductsByPagingQueryHandler : IQueryHandler<GetAllProductsByPagingQuery, (IList<Product>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsByPagingQueryHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<(IList<Product>, int, int)> Handle(GetAllProductsByPagingQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductRepository.GetPagedProducts(query, cancellationToken);
        }
    }
}
