namespace Core.Domain
{
    public class Sprint
    {
        private string _title;

        private string _description;

        private DateTime _startDate;

        private DateTime _endDate;

        public Sprint(string title, string description, DateTime startDate, DateTime endDate)
        {
            _title = title;
            _description = description;
            _startDate = startDate;
            _endDate = endDate;
        }
    }
}
