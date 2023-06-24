using Core.Domain.State;

namespace Core.Domain.Sprints
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
        public string Title
        {
            get => _title;
            set
            {
                if (State is not SprintCreated)
                    throw new InvalidOperationException("Title cannot be set at this state.");

                _title = value;
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (State is not SprintCreated)
                    throw new InvalidOperationException("Description cannot be set at this state.");

                _description = value;
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (State is not SprintCreated)
                    throw new InvalidOperationException("StartDate cannot be set at this state.");

                _startDate = value;
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (State is not SprintCreated)
                    throw new InvalidOperationException("EndDate cannot be set at this state.");

                _endDate = value;
            }
        }

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
