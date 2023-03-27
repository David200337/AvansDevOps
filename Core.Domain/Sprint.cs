namespace Core.Domain
{
    public class Sprint
    {
        private string _title;

        private string _description;

        private DateTime _startDate;

        private DateTime _endDate;

        private User _scrumMaster;

        private List<BacklogItem> _backlog;

        public Sprint(string title, string description, DateTime startDate, DateTime endDate, User scrumMaster)
        {
            _title = title;
            _description = description;
            _startDate = startDate;
            _endDate = endDate;
            _scrumMaster = scrumMaster;
            _backlog = new List<BacklogItem>();
        }

        // Properties
        public string Title => _title;

        public string Description => _description;

        public DateTime StartDate => _startDate;

        public DateTime EndDate => _endDate;

        public User ScrumMaster => _scrumMaster;

        public List<BacklogItem> Backlog => _backlog;

        // Methods
        public void AddBacklogItem(BacklogItem backlogItem) => _backlog.Add(backlogItem);

        public void RemoveBacklogItem(BacklogItem backlogItem) => _backlog.Remove(backlogItem);
    }
}
