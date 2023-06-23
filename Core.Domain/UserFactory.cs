using System;
using Core.Domain.Roles;

namespace Core.Domain
{
    public static class UserFactory<T> where T : User
    {

        public static User CreateUser(User type, string id, string firstName, string lastName, string email, string username)
        {
            switch (type)
            {
                case ProductOwner productOwner:
                    return new ProductOwner(id, firstName, lastName, email, username);
                case ScrumMaster scrumMaster:
                    return new ScrumMaster(id, firstName, lastName, email, username);
                case LeadDeveloper leadDeveloper:
                    return new LeadDeveloper(id, firstName, lastName, email, username);
                case Developer developer:
                    return new Developer(id, firstName, lastName, email, username);
                case Tester tester:
                    return new Tester(id, firstName, lastName, email, username);
                default:
                    throw new Exception("This role has not been implemented.");
            }
        }
    }
}

