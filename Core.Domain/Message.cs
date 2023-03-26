namespace Core.Domain
{
    public class Message
    {
        private readonly string _id;

        private string _content;

        private DateTime _created;

        private User _creator;

        public Message(string id, string content, DateTime created, User creator)
        {
            _id = id;
            _content = content;
            _created = created;
            _creator = creator;
        }
    }
}
