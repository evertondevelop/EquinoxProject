namespace Equinox.Application.EventSourcedNormalizers
{
    /// <summary>
    /// Represents the data for a customer's history event.
    /// </summary>
    public class CustomerHistoryData
    {
        /// <summary>
        /// The type of action that was taken for the customer's history event.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// The unique identifier for the customer.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email address of the customer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The birthdate of the customer.
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// The timestamp of when the customer's history event occurred.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// The unique identifier of the user who performed the action for the customer's history event.
        /// </summary>
        public string Who { get; set; }
    }
}
