using Core.Domain.Pipeline;
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

        private Pipeline.Pipeline _pipeline;

        public Sprint(string title, string description, DateTime startDate, DateTime endDate, User scrumMaster) : base(new SprintCreated())
        {
            _title = title;
            _description = description;
            _startDate = startDate;
            _endDate = endDate;
            _scrumMaster = scrumMaster;
            _backlog = new List<BacklogItem>();
            _pipeline = new Pipeline.Pipeline();
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
        public Pipeline.Pipeline Pipeline => _pipeline;

        // State transitions
        public void SetCreated()
        {
            CheckIfPipelineIsRunning();
            State.SetCreated(this);
        }

        public void SetInProgress()
        {
            CheckIfPipelineIsRunning();
            State.SetInProgress(this);
        }

        public void SetFinished()
        {
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
            if (State is SprintInRelease)
            {
                _pipeline.StartPipeline();
            }
        }

        // Methods
        public void AddBacklogItem(BacklogItem backlogItem) => _backlog.Add(backlogItem);

        public void RemoveBacklogItem(BacklogItem backlogItem) => _backlog.Remove(backlogItem);
    }
}
