using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class MailNotificationService : NotificationService
    {
        public override void SendNotification(Notification notification)
        {
            Console.WriteLine("Sending notification via email...");
            Console.WriteLine(notification.ToString());
            Console.WriteLine("Email notification sent!");
        }
    }
}
