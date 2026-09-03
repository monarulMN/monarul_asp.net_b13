using Cortex.Mediator.Commands;
using MaleFashion.Application.Contracts;
using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Features.Customers.Command
{
    public class CustomerDeleteCommandHandler : ICommandHandler<CustomerDeleteCommand>
    {
        private readonly ICustomerRepository _customerRepository;   

        public CustomerDeleteCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(CustomerDeleteCommand command, CancellationToken cancellationToken)
        {
            await _customerRepository.RemoveAsync(command.Id, cancellationToken);
            await _customerRepository.SaveAsync(cancellationToken);
        }
    }
}
