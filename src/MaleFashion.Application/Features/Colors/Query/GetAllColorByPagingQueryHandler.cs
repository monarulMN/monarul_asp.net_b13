using Cortex.Mediator.Queries;
using MaleFashion.Application.Contracts;
using MaleFashion.Domain.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Colors.Query
{
    internal class GetAllColorByPagingQueryHandler : IQueryHandler<GetAllColorByPagingQuery, (IList<Color>, int, int)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllColorByPagingQueryHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<(IList<Color>, int, int)> Handle(GetAllColorByPagingQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ColorRepository.GetPagedColors(query, cancellationToken);
        }
    }
}
