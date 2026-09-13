using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts;
using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Users.Command
{
    public class UserDeleteCommandHandler : ICommandHandler<UserDeleteCommand>
    {
        private readonly IUserRepository _userRepository;   

        public UserDeleteCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UserDeleteCommand command, CancellationToken cancellationToken)
        {
            await _userRepository.RemoveAsync(command.Id, cancellationToken);
            await _userRepository.SaveAsync(cancellationToken);
        }
    }
}
