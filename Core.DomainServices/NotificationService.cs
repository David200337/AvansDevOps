using Core.Domain;
using Core.Domain.State;

namespace Core.DomainServices
{
    public abstract class NotificationService : Domain.IObserver<BacklogItem>
    {
        public abstract void SendNotification(Notification notification);

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
