namespace Core.Domain
{
    public abstract class User
    {
        private readonly string _id;

        private string _firstName;

        private string _lastName;

        private string _email;

        private string _username;

        private readonly List<IObserver<Notification>> _observers;

        public User(string id, string firstName, string lastName, string email, string username)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _username = username;
            _observers = new List<IObserver<Notification>>();
        }

        public void Update(BacklogItem subject)
        {
            string message = $"User {_username} has been notified of a state update: {subject.State.GetName()}";
            Console.WriteLine(message);

            Notification notification = new Notification(this, message);

            // Notify the listeners of a new notification.
            Notify(notification);
        }

        public void RegisterObserver(IObserver<Notification> observer) => _observers.Add(observer);

        public void RemoveObserver(IObserver<Notification> observer) => _observers.Remove(observer);

        public void Notify(Notification subject) => _observers.ForEach(o => o.Update(subject));
    }
}
