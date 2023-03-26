namespace Core.Domain.States
{
    public class BacklogItemToDo : IBacklogItemState
    {

        public void MoveToNextState(BacklogItem item)
        {
            item.SetState(new BacklogItemInProgress());
        }

        public void MoveToPreviousState(BacklogItem item)
        {
            throw new Exception("A previous state does not exist.");
        }

        public string GetStateName() => "To Do";
    }
}
