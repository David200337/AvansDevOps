namespace Core.Domain
{
    public class Sprint
    {
        private string _title;

        private string _description;

        private DateTime _startDate;

        private DateTime _endDate;

        private User _scrumMaster;

        public Sprint(string title, string description, DateTime startDate, DateTime endDate, User scrumMaster)
        {
            _title = title;
            _description = description;
            _startDate = startDate;
            _endDate = endDate;
            _scrumMaster = scrumMaster;
        }
    }
}
