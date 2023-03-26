namespace Core.Domain
{
    public class Project
    {
        private readonly string _id;

        private string _name;

        private IList<User> _teamMembers;

        public Project(string id, string name)
        {
            _id = id;
            _name = name;
            _teamMembers = new List<User>();
        }

        public void AddTeamMember(User user)
        {
            _teamMembers.Add(user);
        }
    }
}
