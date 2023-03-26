namespace Core.Domain.States
{
    public class BacklogItemReadyForTesting : IBacklogItemState
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
            // Do nothing, already in this state.
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

        public string GetStateName() => "Ready for Testing";
    }
}
