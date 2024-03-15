using System;
using FluentValidation;

namespace Equinox.Domain.Commands
{
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        public RegisterNewCustomerCommand(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RegisterNewCustomerCommandValidation : AbstractValidator<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Birthdate is required.")
                .Must(BeAValidBirthDate).WithMessage("Invalid birthdate.");
        }

        private bool BeAValidBirthDate(DateTime birthDate)
        {
            // Add your custom validation logic here
            // For example, check if the birthdate is in the past
            return birthDate < DateTime.Now;
        }
    }
}
