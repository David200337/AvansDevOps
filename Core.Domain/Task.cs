namespace Core.Domain
{
    public class Task
    {
        private readonly string _id;

        private string _title;

        private string _description;

        private User _assignee;

        public Task(string id, string title, string description, User assignee)
        {
            _id = id;
            _title = title;
            _description = description;
            _assignee = assignee;
        }
    }
}
