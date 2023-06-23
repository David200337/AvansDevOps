using System;
namespace Core.Domain.Roles
{
    public class Developer : User
    {
        public Developer(
            string id,
            string firstName,
            string lastName,
            string email,
            string userName
        ) : base(id, firstName, lastName, email, userName) { }
    }
}

