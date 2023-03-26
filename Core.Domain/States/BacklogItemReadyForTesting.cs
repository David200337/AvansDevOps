namespace Core.Domain.States
{
    public class BacklogItemReadyForTesting : IBacklogItemState
    {
        public void MoveToNextState(BacklogItem item)
        {
            item.SetState(new BacklogItemDone());
        }

        public void MoveToPreviousState(BacklogItem item)
        {
            item.SetState(new BacklogItemInProgress());
        }

        public string GetStateName() => "Ready for Testing";
    }
}
