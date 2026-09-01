using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts;
using MaleFashion.Domain.Entities;
using MaleFashion.Domain.Utilities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Customers.Command
{
    public class CustomerAddCommandHandler : ICommandHandler<CustomerAddCommand, User>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerAddCommandHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<User> Handle(CustomerAddCommand command, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(command);
            user.Id = IdentityGenerator.NewSequentialGuid();

            await _unitOfWork.UserRepository.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return user;
        }
    }
}
