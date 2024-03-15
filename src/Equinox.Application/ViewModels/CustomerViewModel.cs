using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Equinox.Application.ViewModels
{
    /// <summary>
    /// Represents a view model for a customer in the Equinox application.
    /// </summary>
    public class CustomerViewModel
    {
        /// <summary>
        /// The unique identifier for the customer.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the customer. Required, with a minimum length of 2 characters and a maximum length of 100 characters.
        /// </summary>
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The customer's email address. Required and must be a valid email address.
        /// </summary>
        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        /// <summary>
        /// The customer's birth date. Required and displayed in the format yyyy-MM-dd.
        /// </summary>
        [Required(ErrorMessage = "The BirthDate is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}
