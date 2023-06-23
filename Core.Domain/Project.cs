using Core.Domain.Repository;

namespace Core.Domain
{
    public class Project
    {
        private readonly string _id;

        private string _name;

        private IList<User> _teamMembers;

        private IProjectRepository _repository;

        public Project(string id, string name)
        {
            _id = id;
            _name = name;
            _teamMembers = new List<User>();
            _repository = new ProjectRepository();
        }

        public IProjectRepository GetRepository()
        {
            return _repository;
        }

        public void AddTeamMember(User user)
        {
            _teamMembers.Add(user);
        }
    }
}
