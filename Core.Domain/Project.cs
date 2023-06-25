using Core.Domain.Repository;
using Core.Domain.Roles;
using Core.Domain.Sprints;
using Core.Domain.State;

namespace Core.Domain
{
    public class Project
    {
        private readonly string _id;

        private string _name;

        private ProductOwner _productOwner;

        private LeadDeveloper _leadDeveloper;

        // A list of all team member, except for the product owner and lead developer.
        private IList<User> _teamMembers;

        private IList<Sprint> _sprints;

        private Sprint? _activeSprint;

        private IProjectRepository _repository;

        public Project(string id, string name, ProductOwner productOwner, LeadDeveloper leadDeveloper)
        {
            _id = id;
            _name = name;
            _productOwner = productOwner;
            _leadDeveloper = leadDeveloper;
            _teamMembers = new List<User>();
            _sprints = new List<Sprint>();
            _repository = new ProjectRepository();
        }

        // Properties

        public Sprint? ActiveSprint => _activeSprint;
        public IProjectRepository Repository => _repository;

        // Methods

        public void AddTeamMember(User user)
        {
            _teamMembers.Add(user);
        }

        public void CreateSprint(SprintType type, string title, string description, DateTime startDate, DateTime endDate, User scrumMaster)
        {
            foreach (Sprint sprint in _sprints)
            {
                if (sprint.State is SprintInProgress)
                {
                    _activeSprint = sprint;
                    _sprints.Remove(sprint);
                    break;
                }
            }

            switch (type)
            {
                case SprintType.Release:
                    _sprints.Add(new ReleaseSprint(title, description, startDate, endDate, scrumMaster));
                    break;
                case SprintType.Review:
                    _sprints.Add(new ReviewSprint(title, description, startDate, endDate, scrumMaster));
                    break;
                default:
                    throw new Exception("Sprint type not implemented.");
            }
        }
    }
}
