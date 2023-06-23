using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class MailNotificationService : INotificationService, Core.Domain.IObserver<Notification>
    {
        public void SendNotification(string message, User user)
        {
            throw new NotImplementedException();
        }

        public void Update(Notification notification) => Console.WriteLine($"Notification service received a notification request: {0}", notification);
    }
}
