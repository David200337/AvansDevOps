namespace Core.Domain.States
{
    public interface IBacklogItemState
    {
        void SetToDo(BacklogItem item);

        void SetInProgress(BacklogItem item);

        void SetReadyForTesting(BacklogItem item);

        void SetTesting(BacklogItem item);

        void SetTested(BacklogItem item);

        void SetDone(BacklogItem item);

        String GetStateName();
    }
}
