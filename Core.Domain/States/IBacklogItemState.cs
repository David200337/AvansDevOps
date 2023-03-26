namespace Core.Domain.States
{
    public interface IBacklogItemState
    {
        void MoveToNextState(BacklogItem item);

        void MoveToPreviousState(BacklogItem item);

        String GetStateName();
    }
}
