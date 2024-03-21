namespace Core.Domain
{
    public abstract class User
    {
        private readonly string _id;

        private readonly string _firstName;

        private readonly string _lastName;

        private readonly string _email;

        private readonly string _username;

        private readonly List<IObserver<Notification>> _observers;

        protected User(string id, string firstName, string lastName, string email, string username)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _username = username;
            _observers = new List<IObserver<Notification>>();
        }

        public string Id => _id;

        public string FirstName => _firstName;

        public string LastName => _lastName;

        public string FullName => $"{_firstName} {_lastName}";

        public string Email => _email;

        public string Username => _username;

        public void Update(BacklogItem subject)
        {
            var message = $"User {_username} has been notified of a state update: {subject.State.GetName()}";
            Console.WriteLine(message);

            var notification = new Notification(this, message);

            // Notify the listeners of a new notification.
            Notify(notification);
        }

        public void RegisterObserver(IObserver<Notification> observer) => _observers.Add(observer);

        public void RemoveObserver(IObserver<Notification> observer) => _observers.Remove(observer);

        private void Notify(Notification subject) => _observers.ForEach(o => o.Update(subject));
    }
}
