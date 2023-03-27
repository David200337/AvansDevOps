namespace Core.Domain
{
    public class User : IObserver<BacklogItem>
    {
        private readonly string _id;

        private string _firstName;

        private string _lastName;

        private string _email;

        private string _username;


        public User(string id, string firstName, string lastName, string email, string username)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _username = username;
        }

        public void Update(Role role, BacklogItem subject) => Console.WriteLine("User {0} has been notified of a state update: {1}", _username, subject.State.GetName());
    }
}
