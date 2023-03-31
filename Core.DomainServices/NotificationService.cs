using Core.Domain;
using Core.Domain.State;

namespace Core.DomainServices
{
    public abstract class NotificationService : Domain.IObserver<BacklogItem>
    {
        public abstract void SendNotification(Notification notification);

        public void Update(BacklogItem backlogItem)
        {
            // An update of a backlog item has occurred.

            // Depending on the state of the backlog item,
            // a notification should be sent to the appropriate users.
            if (backlogItem.State is BacklogItemReadyForTesting)
            {
                var testers = backlogItem.GetTesters();

                testers.ForEach(t => SendNotification(
                    new Notification(
                        t,
                        $"The backlog item '{backlogItem.Title}', which you have been assigned to as a tester, has been updated to '{backlogItem.State.GetName()}'."
                    )));
            }
        }
    }
}
