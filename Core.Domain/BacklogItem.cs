using Core.Domain.States;

namespace Core.Domain
{
    public class BacklogItem
    {
        private string _id;

        private IBacklogItemState _state;

        private string _title;

        private string _description;

        private User _assignee;

        public BacklogItem(string id, string title, string description, User assignee)
        {
            _id = id;
            _state = new BacklogItemToDo();
            _title = title;
            _description = description;
            _assignee = assignee;
        }

        internal void SetState(IBacklogItemState state)
        {
            _state = state;
        }

        public void MoveToNextState()
        {
            _state.MoveToNextState(this);
        }

        public void MoveToPreviousState()
        {
            _state.MoveToPreviousState(this);
        }
    }
}
