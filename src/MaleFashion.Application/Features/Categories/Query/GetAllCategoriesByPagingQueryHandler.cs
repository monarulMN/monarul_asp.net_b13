using Cortex.Mediator.Queries;
using MaleFashion.Application.Contracts;
using MaleFashion.Domain.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Categories.Query
{
    public class GetAllCategoriesByPagingQueryHandler : IQueryHandler<GetAllCategoriesByPagingQuery,
        (IList<Category>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesByPagingQueryHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<(IList<Category>, int, int)> Handle(GetAllCategoriesByPagingQuery query, 
            CancellationToken cancellationToken)
        {
            return await _unitOfWork.CategoryRepository.GetPagedCategories(query, cancellationToken);
        }
    }
}
