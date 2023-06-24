using System;
using Core.Domain.Roles;

namespace Core.Domain
{
    public static class UserFactory
    {

        public static User CreateUser(Type type, string id, string firstName, string lastName, string email, string username)
        {
            switch (type.Name)
            {
                case nameof(ProductOwner):
                    return new ProductOwner(id, firstName, lastName, email, username);
                case nameof(ScrumMaster):
                    return new ScrumMaster(id, firstName, lastName, email, username);
                case nameof(LeadDeveloper):
                    return new LeadDeveloper(id, firstName, lastName, email, username);
                case nameof(Developer):
                    return new Developer(id, firstName, lastName, email, username);
                case nameof(Tester):
                    return new Tester(id, firstName, lastName, email, username);
                default:
                    throw new Exception("This role has not been implemented.");
            }
        }
    }
}

