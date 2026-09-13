using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Application.Exceptions;
using MaleFashion.Application.DTOs;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Users.Command
{
    public class UserUpdateCommandHandler : ICommandHandler<UserUpdateCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserUpdateCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Handle(UserUpdateCommand command, CancellationToken cancellationToken)
        {
            bool isDuplicateEmail = await _userRepository.IsEmailDuplicateAsync(command.Email, command.Id, cancellationToken);


            if (!isDuplicateEmail)
            {
                var user = await _userRepository.GetByIdAsync(command.Id, cancellationToken);
                user = _mapper.Map(command, user);


                await _userRepository.UpdateAsync(user, cancellationToken);
                await _userRepository.SaveAsync(cancellationToken);

            }
            else
                throw new DuplicateDataException("User email is duplicate.");

        }
    }
}
