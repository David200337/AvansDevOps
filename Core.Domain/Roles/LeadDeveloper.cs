using System;
namespace Core.Domain.Roles
{
    public class LeadDeveloper : User
    {
        public LeadDeveloper(
            string id,
            string firstName,
            string lastName,
            string email,
            string userName
        ) : base(id, firstName, lastName, email, userName) { }
    }
}

