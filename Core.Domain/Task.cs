namespace Core.Domain
{
    public class Task
    {
        private readonly string _id;

        private string _title;

        private string _description;

        private User? _assignee;

        public Task(string id, string title, string description, User assignee)
        {
            _id = id;
            _title = title;
            _description = description;
            _assignee = assignee;
        }

        // Properties
        public string Id => _id;

        public string Title => _title;

        public string Description => _description;

        public User? Assignee => _assignee;

        // Methods
        public void AddAssignee(User assignee) => _assignee = assignee;

        public void RemoveAssignee() => _assignee = null;
    }
}
