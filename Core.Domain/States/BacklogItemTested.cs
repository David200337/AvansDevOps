namespace Core.Domain.States
{
    public class BacklogItemTested : IBacklogItemState
    {


        public void MoveToNextState(BacklogItem item)
        {
            throw new NotImplementedException();
        }

        public void MoveToPreviousState(BacklogItem item)
        {
            item.SetState(new BacklogItemTesting());
        }

        public string GetStateName() => "Tested";
    }
}
