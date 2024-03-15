using System;

namespace Equinox.Domain.Events
{
    public class CustomerRegisteredEvent : Event
    {
        public CustomerRegisteredEvent(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            AggregateId = id;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Email { get; }

        public DateTime BirthDate { get; }
    }
}
