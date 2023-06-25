using Core.Domain;
using Core.Domain.State;
using Core.DomainServices;

namespace Infrastructure
{
    public class MailNotificationService : INotificationService, Core.Domain.IObserver<BacklogItem>
    {
        private string _email;

        MailNotificationService(string email)
        {
            _email = email;
        }

        public void SendNotification(Notification notification)
        {
            Console.WriteLine($"Sent user {notification.User.FullName} the following message: \'{notification.Message}\' to email address: \'{_email}\'.");
        }

        public void UpdateWithPreviousState(BacklogItem previous, BacklogItem current)
        {
            // An update of a backlog item has occurred.

            // Check if the state has changed.
            if (!previous.State.Equals(current.State))
            {
                // Depending on the state of the backlog item,
                // a notification should be sent to the appropriate users.
                if (current.State is BacklogItemReadyForTesting)
                {
                    var testers = current.GetTesters();
                    testers.ForEach(t => SendNotification(
                    new Notification(
                        t,
                        $"The backlog item '{current.Title}', which you have been assigned to as a tester, has been updated to '{current.State.GetName()}'."
                    )));
                }
            }
        }
    }
}
