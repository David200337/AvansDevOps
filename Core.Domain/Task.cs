using Core.Domain.State;

namespace Core.Domain
{
    public class Task : Stateful<TaskState>
    {
        private readonly string _id;

        private readonly string _title;

        private readonly string _description;

        private User? _assignee;

        public Task(string id, string title, string description, User assignee) : base(new TaskToDo())
        {
            _id = id;
            _title = title;
            _description = description;
            _assignee = assignee;
        }

        // Properties
        public string Id => _id;

        public string Title => _title;

        public string Description => _description;

        public User? Assignee => _assignee;

        // State transitions
        public void SetToDo() => State.SetToDo(this);

        public void SetInProgress() => State.SetInProgress(this);

        public void SetReadyForTesting() => State.SetReadyForTesting(this);

        public void SetTesting() => State.SetTesting(this);

        public void SetTested() => State.SetTested(this);

        public void SetDone() => State.SetDone(this);

        // Methods
        public void AddAssignee(User assignee) => _assignee = assignee;

        public void RemoveAssignee() => _assignee = null;
    }
}
