using System; // Needed for working with basic language features, such as data types and flow control statements
using Equinox.Domain.Commands.Validations; // Namespace for command validations

namespace Equinox.Domain.Commands // Namespace for Equinox's command-related functionality
{
    public class RemoveCustomerCommand : CustomerCommand // Inherits from CustomerCommand base class
    {
        public RemoveCustomerCommand(Guid customerId) : base(customerId) // Constructor with a single parameter: the customer's ID
        {
            AggregateId = customerId; // Assigns the provided ID to the 'AggregateId' property
        }

        public override bool IsValid() // Overrides the base class's 'IsValid' method
        {
            ValidationResult = new RemoveCustomerCommandValidation().Validate(this); // Validates the command using the 'RemoveCustomerCommandValidation' class
            return ValidationResult.IsValid; // Returns the validation result
        }
    }
}
