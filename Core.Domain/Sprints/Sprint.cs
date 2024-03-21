using Core.Domain.Pipeline;
using Core.Domain.State;

namespace Core.Domain.Sprints
{
    public abstract class Sprint : Stateful<SprintState>, ISubject<Sprint>
    {
        private readonly string _id;

        private string _title;

        private string _description;

        private DateTime _startDate;

        private DateTime _endDate;

        private readonly User _scrumMaster;

        private readonly List<BacklogItem> _backlog;

        private readonly Pipeline.Pipeline _pipeline;

        private readonly List<IObserver<Sprint>> _observers;

        protected Sprint(string id, string title, string description, DateTime startDate, DateTime endDate, User scrumMaster) : base(new SprintCreated())
        {
            _id = id;
            _title = title;
            _description = description;
            _startDate = startDate;
            _endDate = endDate;
            _scrumMaster = scrumMaster;
            _backlog = new List<BacklogItem>();
            _pipeline = new Pipeline.Pipeline();
            _observers = new List<IObserver<Sprint>>();
        }

        // Properties
        public string Id => _id;

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
        public Pipeline.Pipeline Pipeline => _pipeline;

        // State transitions
        public void SetCreated()
        {
            CheckIfPipelineIsRunning();
            State.SetCreated(this);
        }

        public void SetInProgress()
        {
            var previous = ShallowCopy();
            CheckIfPipelineIsRunning();
            State.SetInProgress(this);
            NotifyWithPreviousState(previous, this);
        }

        public void SetFinished()
        {
            if (_startDate < DateTime.Now)
            {
                throw new InvalidOperationException("Cannot finish a sprint before it's end date.");
            }

            CheckIfPipelineIsRunning();
            State.SetFinished(this);
        }

        public void SetInRelease()
        {
            CheckIfPipelineIsRunning();
            State.SetInRelease(this);
        }

        public void SetReleased()
        {
            CheckIfPipelineIsRunning();
            State.SetReleased(this);
        }

        public void SetReleaseCancelled()
        {
            CheckIfPipelineIsRunning();
            State.SetReleaseCancelled(this);
        }

        private void CheckIfPipelineIsRunning()
        {
            if (_pipeline.IsStarted)
            {
                throw new InvalidOperationException("Cannot change state while pipeline is running.");
            }
        }

        public void StartPipeline()
        {
            if (State is not SprintInRelease) throw new InvalidOperationException("Sprint state should be in release.");

            _pipeline.StartPipeline();
        }

        // Observer pattern
        public void RegisterObserver(IObserver<Sprint> observer) => _observers.Add(observer);

        public void RemoveObserver(IObserver<Sprint> observer) => _observers.Remove(observer);

        public void NotifyWithPreviousState(Sprint previous, Sprint current) => _observers.ForEach(o => o.UpdateWithPreviousState(previous, current));

        // Methods
        public void AddBacklogItem(BacklogItem backlogItem) => _backlog.Add(backlogItem);

        public void RemoveBacklogItem(BacklogItem backlogItem) => _backlog.Remove(backlogItem);

        private Sprint ShallowCopy() => (Sprint)MemberwiseClone();

        public string GenerateReport(string header, string footer, List<User> teamMembers)
        {
            if (State is not SprintFinished) throw new InvalidOperationException("A report cannot be generated on a sprint that is not yet finished.");

            var report = new SprintReport(this, header, footer, teamMembers);
            return report.GenerateReport();
        }
    }
}
