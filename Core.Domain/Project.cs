<<<<<<< HEAD
﻿using Core.Domain.Repository;
=======
﻿using Core.Domain.Roles;
using Core.Domain.Sprints;
>>>>>>> feature/domain-design

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

<<<<<<< HEAD
        private IProjectRepository _repository;

        public Project(string id, string name)
=======
        private IList<Sprint> _sprints;

        private Sprint? _activeSprint;

        public Project(string id, string name, ProductOwner productOwner, LeadDeveloper leadDeveloper)
>>>>>>> feature/domain-design
        {
            _id = id;
            _name = name;
            _productOwner = productOwner;
            _leadDeveloper = leadDeveloper;
            _teamMembers = new List<User>();
<<<<<<< HEAD
            _repository = new ProjectRepository();
        }

        public IProjectRepository GetRepository()
        {
            return _repository;
=======
            _sprints = new List<Sprint>();
>>>>>>> feature/domain-design
        }

        // Properties

        public Sprint? ActiveSprint => _activeSprint;

        // Methods

        public void AddTeamMember(User user)
        {
            _teamMembers.Add(user);
        }

        public void CreateSprint(SprintType type, string title, string description, DateTime startDate, DateTime endDate, User scrumMaster)
        {
            // TODO: Observe each sprint and set the sprint as the `activeSprint`
            // once the sprint goes to in progress.
            // This way, we ensure the project is always aware of the current active sprint.
            // Once a sprint goes to in progress, the sprint should be removed from the `_srpints` list
            // and assigned to the `_activeSprint` attribute.

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
