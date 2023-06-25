using Core.Domain.Repository;
using Core.Domain.Roles;
using Core.Domain.Sprints;
using Core.Domain.State;

namespace Core.Domain
{
    public class Project : Core.Domain.IObserver<Sprint>
    {
        private readonly string _id;

        private string _title;

        private ProductOwner _productOwner;

        private LeadDeveloper _leadDeveloper;

        // A list of all team member, except for the product owner and lead developer.
        private IList<User> _teamMembers;

        private IList<Sprint> _sprints;

        private Sprint? _activeSprint;

        private IProjectRepository _repository;

        public Project(string id, string title, ProductOwner productOwner, LeadDeveloper leadDeveloper)
        {
            _id = id;
            _title = title;
            _productOwner = productOwner;
            _leadDeveloper = leadDeveloper;
            _teamMembers = new List<User>();
            _sprints = new List<Sprint>();
            _repository = new ProjectRepository();
        }

        // Properties
        public string Id => _id;

        public string Title => _title;

        public ProductOwner ProductOwner => _productOwner;

        public LeadDeveloper LeadDeveloper => _leadDeveloper;

        public IProjectRepository Repository => _repository;

        // Methods

        public void AddTeamMember(User user) => _teamMembers.Add(user);

        public IList<User> GetTeamMembers() => _teamMembers;

        public void CreateSprint(SprintType type, string id, string title, string description, DateTime startDate, DateTime endDate, User scrumMaster)
        {
            switch (type)
            {
                case SprintType.Release:
                    CreateReleaseSprint(id, title, description, startDate, endDate, scrumMaster);
                    break;
                case SprintType.Review:
                    CreateReviewSprint(id, title, description, startDate, endDate, scrumMaster);
                    break;
                case SprintType.Feedback:
                    CreateFeedbackSprint(id, title, description, startDate, endDate, scrumMaster);
                    break;
                default:
                    throw new Exception("Sprint type not implemented.");
            }
        }

        public IList<Sprint> GetSprints() => _sprints;

        public Sprint? GetSprint(string id) => _sprints.FirstOrDefault(s => s.Id.Equals(id));

        public Sprint? GetActiveSprint() => _activeSprint;

        public void StartSpint(string sprintId)
        {
            // Find the sprint in the list of sprints.
            var sprint = _sprints.FirstOrDefault(s => s.Id.Equals(sprintId));
            if (sprint is null) throw new Exception("Sprint not found");

            sprint.SetInProgress();
        }

        public void FinishSprint()
        {
            if (_activeSprint is null) throw new Exception("No active sprint.");

            _activeSprint.SetFinished();
        }

        public void UpdateWithPreviousState(Sprint previous, Sprint current)
        {
            // An update of a sprint has occurred.

            // Check if the state has changed.
            if (!previous.State.Equals(current.State))
            {
                // Perform an action based on the new sprint state.
                switch (current.State)
                {
                    case SprintInProgress:
                        // Set the sprint as the active sprint
                        // and remove the sprint from the list of sprints.
                        _activeSprint = current;
                        _sprints.Remove(current);
                        break;
                    default:
                        Console.WriteLine("State not implemented");
                        break;
                }
            }
        }

        private void CreateReleaseSprint(string id, string title, string description, DateTime startDate, DateTime endDate, User scrumMaster)
        {
            var releaseSprint = new ReleaseSprint(id, title, description, startDate, endDate, scrumMaster);
            releaseSprint.RegisterObserver(this);

            _sprints.Add(releaseSprint);
        }

        private void CreateReviewSprint(string id, string title, string description, DateTime startDate, DateTime endDate, User scrumMaster)
        {
            var reviewSprint = new ReviewSprint(id, title, description, startDate, endDate, scrumMaster);
            reviewSprint.RegisterObserver(this);

            _sprints.Add(reviewSprint);
        }

        private void CreateFeedbackSprint(string id, string title, string description, DateTime startDate, DateTime endDate, User scrumMaster)
        {
            var feedbackSprint = new ReviewSprint(id, title, description, startDate, endDate, scrumMaster);
            feedbackSprint.RegisterObserver(this);

            _sprints.Add(feedbackSprint);
        }
    }
}
