using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper; // AutoMapper is used for mapping objects between different layers of the application
using Equinox.Application.EventSourcedNormalizers;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands;
using Equinox.Domain.Interfaces;
using Equinox.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results; // FluentValidation is used for validation of objects
using NetDevPack.Mediator; // NetDevPack.Mediator is used for mediating commands and queries

namespace Equinox.Application.Services
{
    public class CustomerAppService : ICustomerAppService // Implements the ICustomerAppService interface
    {
        private readonly IMapper _mapper; // IMapper for mapping objects
        private readonly ICustomerRepository _customerRepository; // Repository for managing customer data
        private readonly IEventStoreRepository _eventStoreRepository; // Repository for managing event sourcing data
        private readonly IMediatorHandler _mediator; // IMediator for mediating commands and queries

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediatorHandler mediator,
                                  IEventStoreRepository eventStoreRepository) // Constructor
        {
            _mapper = mapper; // Initialize IMapper
            _customerRepository = customerRepository; // Initialize ICustomerRepository
            _mediator = mediator; // Initialize IMediator
            _eventStoreRepository = eventStoreRepository; // Initialize IEventStoreRepository
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll() // Gets all customers
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.GetAll()); // Maps the result to CustomerViewModel using IMapper
        }

        public async Task<CustomerViewModel> GetById(Guid id) // Gets a customer by ID
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetById(id)); // Maps the result to CustomerViewModel using IMapper
        }

        public async Task<ValidationResult> Register(CustomerViewModel customerViewModel) // Registers a new customer
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel); // Maps the CustomerViewModel to RegisterNewCustomerCommand using IMapper
            return await _mediator.SendCommand(registerCommand); // Sends the command to the mediator
        }

        public async Task<ValidationResult> Update(CustomerViewModel customerViewModel) // Updates an existing customer
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel); // Maps the CustomerViewModel to UpdateCustomerCommand using IMapper
            return await _mediator.SendCommand(updateCommand); // Sends the command to the mediator
        }

        public async Task<ValidationResult> Remove(Guid id) // Removes a customer
        {
            var removeCommand = new RemoveCustomerCommand(id); // Creates a new RemoveCustomerCommand
            return await _mediator.SendCommand(removeCommand); // Sends the command to the mediator
        }

        public async Task<IList<CustomerHistoryData>> GetAllHistory(Guid id) // Gets the history of a customer
        {
            return CustomerHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id)); // Converts the history to CustomerHistoryData and returns it
        }

        public void Dispose() // Disposes of the object
        {
            GC.SuppressFinalize(this); // Suppresses finalization of the object
        }
    }
}
