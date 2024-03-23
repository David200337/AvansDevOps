using System;
namespace Core.Domain.Roles
{
    public class ProductOwner : User
    {
        public ProductOwner(
            string id,
            string firstName,
            string lastName,
            string email,
            string userName
        ) : base(id, firstName, lastName, email, userName) { }
    }
}

