namespace Equinox.UI.Web.Models
{
    /// <summary>
    /// Represents a view model for displaying error information to the user.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the error code associated with this error.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the title of the error message.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the detailed message describing the error.
        /// </summary>
        public string Message { get; set; }
    }
}
