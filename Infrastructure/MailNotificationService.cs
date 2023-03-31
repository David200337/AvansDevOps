using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class MailNotificationService : INotificationService, Core.Domain.IObserver<BacklogItem>
    {
        public void SendNotification(Notification notification)
        {
            throw new NotImplementedException();
        }

        public void Update(BacklogItem backlogItem) => Console.WriteLine($"Notification service received a backlog item update: {0}", backlogItem);
    }
}
