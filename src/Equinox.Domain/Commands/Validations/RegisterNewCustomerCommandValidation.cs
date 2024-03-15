namespace Equinox.Domain.Commands.Validations
{
    /// <summary>
    /// Validation class for the RegisterNewCustomerCommand. Inherits from the CustomerValidation class.
    /// </summary>
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the RegisterNewCustomerCommandValidation class.
        /// </summary>
        public RegisterNewCustomerCommandValidation()
        {
            // Validate the name of the customer
            ValidateName();

            // Validate the birth date of the customer
            ValidateBirthDate();

            // Validate the email of the customer
            ValidateEmail();
        }
    }
}
