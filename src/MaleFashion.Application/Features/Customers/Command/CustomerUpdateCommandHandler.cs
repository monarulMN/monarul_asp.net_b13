using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Application.Exceptions;
using MaleFashion.Domain.DTOs;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Customers.Command
{
    public class CustomerUpdateCommandHandler : ICommandHandler<CustomerUpdateCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerUpdateCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task Handle(CustomerUpdateCommand command, CancellationToken cancellationToken)
        {
            bool isDuplicateEmail = await _customerRepository.IsEmailDuplicateAsync(command.Email, command.Id, cancellationToken);


            if (!isDuplicateEmail)
            {
                var customer = await _customerRepository.GetByIdAsync(command.Id, cancellationToken);
                customer = _mapper.Map(command, customer);


                await _customerRepository.UpdateAsync(customer, cancellationToken);
                await _customerRepository.SaveAsync(cancellationToken);

            }
            else
                throw new DuplicateDataException("Customer email is duplicate.");

        }
    }
}
