using System;
using Core.Domain.Roles;

namespace Core.Domain
{
    public static class UserFactory
    {

        public static T CreateUser<T>(string id, string firstName, string lastName, string email, string username) where T : User
        {
            switch (typeof(T).Name)
            {
                case nameof(ProductOwner):
                    return (T)(object)new ProductOwner(id, firstName, lastName, email, username);
                case nameof(ScrumMaster):
                    return (T)(object)new ScrumMaster(id, firstName, lastName, email, username);
                case nameof(LeadDeveloper):
                    return (T)(object)new LeadDeveloper(id, firstName, lastName, email, username);
                case nameof(Developer):
                    return (T)(object)new Developer(id, firstName, lastName, email, username);
                case nameof(Tester):
                    return (T)(object)new Tester(id, firstName, lastName, email, username);
                default:
                    throw new Exception("This role has not been implemented.");
            }
        }
    }
}

