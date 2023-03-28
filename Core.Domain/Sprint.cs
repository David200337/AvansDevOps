using Core.Domain.State;

namespace Core.Domain
{
    public abstract class Sprint : Stateful<SprintState>
    {
        private string _title;

        private string _description;

        private DateTime _startDate;

        private DateTime _endDate;

        private User _scrumMaster;

        private List<BacklogItem> _backlog;

        public Sprint(string title, string description, DateTime startDate, DateTime endDate, User scrumMaster) : base(new SprintCreated())
        {
            _title = title;
            _description = description;
            _startDate = startDate;
            _endDate = endDate;
            _scrumMaster = scrumMaster;
            _backlog = new List<BacklogItem>();
        }

        // Properties
        public string Title => _title;

        public string Description => _description;

        public DateTime StartDate => _startDate;

        public DateTime EndDate => _endDate;

        public User ScrumMaster => _scrumMaster;

        public List<BacklogItem> Backlog => _backlog;

        // State transitions
        public void SetCreated() => State.SetCreated(this);

        public void SetInProgress() => State.SetInProgress(this);

        public void SetFinished() => State.SetFinished(this);

        public void SetInRelease() => State.SetInRelease(this);

        public void SetReleased() => State.SetReleased(this);

        public void SetReleaseCancelled() => State.SetReleaseCancelled(this);

        // Methods
        public void AddBacklogItem(BacklogItem backlogItem) => _backlog.Add(backlogItem);

        public void RemoveBacklogItem(BacklogItem backlogItem) => _backlog.Remove(backlogItem);
    }
}
