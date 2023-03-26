namespace Core.Domain.States
{
    public class BacklogItemToDo : IBacklogItemState
    {
        public void SetToDo(BacklogItem item)
        {
            // Do nothing, already in this state.
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
            item.SetTesting();
        }

        public void SetTested(BacklogItem item)
        {
            item.SetTested();
        }

        public void SetDone(BacklogItem item)
        {
            item.SetDone();
        }

        public string GetStateName() => "To Do";
    }
}
