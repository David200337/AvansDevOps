namespace Core.Domain.States
{
    internal class BacklogItemTesting : IBacklogItemState
    {
        public void MoveToNextState(BacklogItem item)
        {
            item.SetState(new BacklogItemTested());
        }

        public void MoveToPreviousState(BacklogItem item)
        {
            item.SetState(new BacklogItemInProgress());
        }

        public string GetStateName() => "Testing";
    }
}
