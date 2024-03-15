using System;
using NetDevPack.Messaging; // This using statement includes the NetDevPack.Messaging namespace, which provides functionality for messaging in the application.

namespace Equinox.Domain.Events // This namespace contains classes related to events in the Equinox domain.
{
    public class CustomerRemovedEvent : Event // This class represents a domain event that occurs when a customer is removed.
    {
        public CustomerRemovedEvent(Guid id) // The constructor initializes the event with a unique identifier for the customer.
        {
            Id = id; // The Id property represents the unique identifier for the customer.
            AggregateId = id; // The AggregateId property represents the unique identifier for the aggregate root, which is the customer in this case.
        }

        public Guid Id { get; set; } // The Id property is a unique identifier for the customer.
    }
}
