using System;
namespace Core.Domain.Roles
{
    public class Tester : User
    {
        public Tester(
            string id,
            string firstName,
            string lastName,
            string email,
            string userName
        ) : base(id, firstName, lastName, email, userName) { }
    }
}

