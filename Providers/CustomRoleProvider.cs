using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Transport.Repository;

namespace Transport.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public CustomRoleProvider()
        {
        }
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            return new string[] { UnitOfWork.context.Customers.FirstOrDefault(x => x.Email == username).Role };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return UnitOfWork.context.Customers.Where(x => x.Role == roleName).Select(x => x.Email).ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return UnitOfWork.context.Customers.FirstOrDefault(x => x.Email == username).Role == roleName;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}