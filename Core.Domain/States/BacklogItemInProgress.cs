namespace Core.Domain.States
{
    public class BacklogItemInProgress : IBacklogItemState
    {
        public void MoveToNextState(BacklogItem item)
        {
            item.SetState(new BacklogItemReadyForTesting());
        }
        public void MoveToPreviousState(BacklogItem item)
        {
            item.SetState(new BacklogItemToDo());
        }
        public string GetStateName() => "In Progress";
    }
}
