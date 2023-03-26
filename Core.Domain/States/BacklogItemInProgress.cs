namespace Core.Domain.States
{
    public class BacklogItemInProgress : IBacklogItemState
    {
        public void SetToDo(BacklogItem item)
        {
            item.SetToDo();
        }

        public void SetInProgress(BacklogItem item)
        {
            // Do nothing, already in this state.
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

        public string GetStateName() => "In Progress";
    }
}
