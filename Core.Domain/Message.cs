namespace Core.Domain
{
    public class Message
    {
        private readonly Guid _id;

        private readonly string _content;

        private readonly DateTime _createdAt;

        private readonly User _author;

        public Message(Guid id, string content, DateTime createdAt, User author)
        {
            _id = id;
            _content = content;
            _createdAt = createdAt;
            _author = author;
        }

        public Guid Id => _id;

        public string Content => _content;

        public DateTime CreatedAt => _createdAt;

        public User Author => _author;
    }
}
