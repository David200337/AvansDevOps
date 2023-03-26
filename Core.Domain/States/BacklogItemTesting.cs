namespace Core.Domain.States
{
    internal class BacklogItemTesting : IBacklogItemState
    {
        public void SetToDo(BacklogItem item)
        {
            item.SetToDo();
        }

        public void SetInProgress(BacklogItem item)
        {
            item.SetInProgress();
        }

        public void SetReadyForTesting(BacklogItem item)
        {
            item.SetReadyForTesting();
        }

        public void SetTesting(BacklogItem item)
        {
            // Do nothing, already in this state.
        }

        public void SetTested(BacklogItem item)
        {
            item.SetTested();
        }

        public void SetDone(BacklogItem item)
        {
            item.SetDone();
        }

        public string GetStateName() => "Testing";
    }
}
