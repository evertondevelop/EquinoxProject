using System;
using NetDevPack.Messaging;

namespace Equinox.Domain.Commands
{
    // This is the base class for all customer-related commands in the system.
    // It inherits from the Command class and provides properties for common customer attributes.
    public abstract class CustomerCommand : Command
    {
        // The unique identifier for the customer.
        public Guid Id { get; protected set; }

        // The name of the customer.
        public string Name { get; protected set; }

        // The email address of the customer.
        public string Email { get; protected set; }

        // The date of birth of the customer.
        public DateTime BirthDate { get; protected set; }

        // Constructor for the CustomerCommand class.
        // Sets the Id, Name, Email, and BirthDate properties.
        protected CustomerCommand(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
    }
}
