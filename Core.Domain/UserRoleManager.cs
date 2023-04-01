namespace Core.Domain
{
    public class UserRoleManager
    {
        private Dictionary<Role, List<User>> _roleUser;

        public UserRoleManager()
        {
            _roleUser = new Dictionary<Role, List<User>>();
        }

        public void AddUserToRole(User user, Role role)
        {
            // Add the role to the dictionary if it does not yet exist.
            if (!_roleUser.ContainsKey(role))
            {
                _roleUser[role] = new List<User>();
            }

            // Add the user to the role if it does not yet exist.
            if (!_roleUser[role].Contains(user))
            {
                _roleUser[role].Add(user);
            }
        }

        public void RemoveUserFromRole(User user, Role role)
        {
            if (_roleUser.ContainsKey(role))
            {
                _roleUser[role].Remove(user);
            }
        }

        public List<User> GetUsersByRole(Role role)
        {
            if (_roleUser.TryGetValue(role, out var users)) return users;

            return new List<User>();
        }

    }
}
