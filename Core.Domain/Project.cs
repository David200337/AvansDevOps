namespace Core.Domain
{
    public class Project
    {
        private readonly string _id;

        private readonly string _name;

        public Project(string id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
