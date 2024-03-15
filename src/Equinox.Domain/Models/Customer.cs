using System;
using NetDevPack.Domain;

namespace Equinox.Domain.Models
{
    /// <summary>
    /// Represents a customer in the Equinox system.
    /// </summary>
    public class Customer : Entity, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <param name="name">The name of the customer.</param>
        /// <param name="email">The email address of the customer.</param>
        /// <param name="birthDate">The birth date of the customer.</param>
        public Customer(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class without any initial values.
        /// </summary>
        protected Customer() { }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the email address of the customer.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the birth date of the customer.
        /// </summary>
        public DateTime BirthDate { get; private set; }
    }
}
