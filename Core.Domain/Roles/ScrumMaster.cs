using System;
namespace Core.Domain.Roles
{
    public class ScrumMaster : User
    {
        public ScrumMaster(
            string id,
            string firstName,
            string lastName,
            string email,
            string userName
        ) : base(id, firstName, lastName, email, userName) { }
    }
}

