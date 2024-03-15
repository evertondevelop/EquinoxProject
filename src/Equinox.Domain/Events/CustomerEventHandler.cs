using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Equinox.Domain.Events
{
    // This class handles various Customer events by implementing the INotificationHandler interface for each event type.
    // It is responsible for performing any necessary actions when a Customer is registered, updated, or removed.
    public class CustomerEventHandler :
        INotificationHandler<CustomerRegisteredEvent>,
        INotificationHandler<CustomerUpdatedEvent>,
        INotificationHandler<CustomerRemovedEvent>
    {
        // Handles the CustomerUpdatedEvent by sending a notification email.
        public Task Handle(CustomerUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send a notification email to the customer

            return Task.CompletedTask;
        }

        // Handles the CustomerRegisteredEvent by sending a greetings email.
        public Task Handle(CustomerRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send a greetings email to the customer

            return Task.CompletedTask;
        }

        // Handles the CustomerRemovedEvent by sending a see you soon email.
        public Task Handle(CustomerRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send a see you soon email to the customer

            return Task.CompletedTask;
        }
    }
}
