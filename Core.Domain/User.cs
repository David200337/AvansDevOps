namespace Core.Domain
{
    public class User
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
    }
}
