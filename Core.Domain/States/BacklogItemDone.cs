namespace Core.Domain.States
{
    public class BacklogItemDone : IBacklogItemState
    {
        public void MoveToNextState(BacklogItem item)
        {
            throw new Exception("A next state does not exist.");
        }

        public void MoveToPreviousState(BacklogItem item)
        {
            item.SetState(new BacklogItemReadyForTesting());
        }

        public string GetStateName() => "Done";
    }
}
