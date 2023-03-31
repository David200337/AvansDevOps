namespace Core.Domain
{
    public class Notification
    {
        private User _user;
        private string _message;

        public Notification(User user, string message)
        {
            _user = user;
            _message = message;
        }

        public User User
        {
            get => _user;
            set => _user = value;
        }

        public string Message
        {
            get => _message;
            set => _message = value;
        }

        public override string ToString() => $"User: {_user}, Message: {_message}";
    }
}
