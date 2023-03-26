namespace Core.Domain
{
    internal class Discussion
    {
        private readonly string _id;

        private string _title;

        public Discussion(string id, string title)
        {
            _id = id;
            _title = title;
        }
    }
}
