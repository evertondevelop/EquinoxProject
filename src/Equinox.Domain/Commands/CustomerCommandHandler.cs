using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Equinox.Domain.Events; // Namespace for domain events
using Equinox.Domain.Interfaces; // Namespace for customer repository interface
using Equinox.Domain.Models; // Namespace for Customer and related domain events
using FluentValidation.Results; // Namespace for validation results
using MediatR; // Namespace for handling commands
using NetDevPack.Messaging; // Namespace for request/response objects and validation

namespace Equinox.Domain.Commands // Namespace for commands and command handlers
{
    public class CustomerCommandHandler : IRequestHandler<RegisterNewCustomerCommand, ICommandResult>,
        IRequestHandler<UpdateCustomerCommand, ICommandResult>,
        IRequestHandler<RemoveCustomerCommand, ICommandResult>
    {
        private readonly ICustomerRepository _customerRepository; // Customer repository instance

        // Constructor with dependency injection for ICustomerRepository
        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Handles RegisterNewCustomerCommand
        public async Task<ICommandResult> Handle(RegisterNewCustomerCommand message, CancellationToken cancellationToken)
        {
            // Validate the incoming command
            if (!message.IsValid()) return new CommandResult(message.ValidationResult, false);

            // Create a new Customer instance with the provided data
            var customer = new Customer(Guid.NewGuid(), message.Name, message.Email, message.BirthDate);

            // Check if a customer with the same email already exists in the repository
            if (await _customerRepository.GetByEmail(customer.Email) != null)
            {
                // If so, add an error to the validation result
                AddError("The customer e-mail has already been taken.");
                return new CommandResult(ValidationResult, false);
            }

            // Add a CustomerRegisteredEvent domain event to the customer instance
            customer.AddDomainEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

            // Add the customer to the repository and commit the changes
            _customerRepository.Add(customer);
            await _customerRepository.Commit();

            return new CommandResult(customer, true);
        }

        // Handles UpdateCustomerCommand
        public async Task<ICommandResult> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            // Validate the incoming command
            if (!message.IsValid()) return new CommandResult(message.ValidationResult, false);

            // Create a new Customer instance with the provided data
            var customer = new Customer(message.Id, message.Name, message.Email, message.BirthDate);

            // Get the existing customer with the same email from the repository
            var existingCustomer = await _customerRepository.GetByEmail(customer.Email);

            // Check if the existing customer's email matches the new customer's email and they're not the same customer
            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    // If so, add an error to the validation result
                    AddError("The customer e-mail has already been taken.");
                    return new CommandResult(ValidationResult, false);
                }
            }

            // Add a CustomerUpdatedEvent domain event to the customer instance
            customer.AddDomainEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

            // Update the customer in the repository and commit the changes
            _customerRepository.Update(customer);
            await _customerRepository.Commit();

            return new CommandResult(customer, true);
        }

        // Handles RemoveCustomerCommand
        public async Task<ICommandResult> Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            // Validate the incoming command
            if (!message.IsValid()) return new CommandResult(message.ValidationResult, false);

            // Get the customer from the repository
            var customer = await _customerRepository.GetById(message.Id);

            // If the customer doesn't exist, add an error to the validation result
            if (customer is null)
            {
                AddError("The customer doesn't exists.");
                return new CommandResult(ValidationResult, false);
            }

            // Add a CustomerRemovedEvent domain event to the customer instance
            customer.AddDomainEvent(new CustomerRemovedEvent(message.Id));

            // Remove the customer from the repository and commit the changes
            _customerRepository.Remove(customer);
            await _customerRepository.Commit();

            return new CommandResult(customer, true);
        }

        // Dispose of the customer repository
        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}

