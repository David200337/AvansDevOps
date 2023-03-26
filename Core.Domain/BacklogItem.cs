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

        public void SetToDo()
        {
            _state.SetToDo(this);
        }

        public void SetInProgress()
        {
            _state.SetInProgress(this);
        }

        public void SetReadyForTesting()
        {
            _state.SetReadyForTesting(this);
        }

        public void SetTesting()
        {
            _state.SetTesting(this);
        }

        public void SetTested()
        {
            _state.SetTested(this);
        }

        public void SetDone()
        {
            _state.SetDone(this);
        }
    }
}
