using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts;
using MaleFashion.Application.Exceptions;
using MaleFashion.Domain.Entities;
using MaleFashion.Domain.Utilities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Colors.Command
{
    public class ColorAddCommandHandler : ICommandHandler<ColorAddCommand, Color>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorAddCommandHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;            
        }

        public async Task<Color> Handle(ColorAddCommand command, CancellationToken cancellationToken)
        {
            var isDuplicateName = await _unitOfWork.ColorRepository.IsDuplicateColorName(command.Name, null, cancellationToken);

            if (!isDuplicateName)
            {
                var color = _mapper.Map<Color>(command.Name);
                color.Id = IdentityGenerator.NewSequentialGuid();

                await _unitOfWork.ColorRepository.AddAsync(color, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);

                return color;
            }
            else
                throw new DuplicateDataException("Color name is duplicate!");
        }
    }
}
