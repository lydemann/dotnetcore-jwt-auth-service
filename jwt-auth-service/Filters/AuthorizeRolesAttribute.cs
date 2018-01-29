using jwt_auth_service.Helpers;
using Microsoft.AspNetCore.Authorization;
using System;

namespace jwt_auth_service.Filters
{
    public enum Role
    {
        TeamRole = 0
    }

    /// <summary>
    /// Set authorization roles from AD groups.
    /// </summary>
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params Role[] roles)
        {
            //var roleNames = String.Empty;

            //if (roles.Length == 1)
            //{
            //    roleNames = RolesHelper.GetRoles(roles[0]);
            //}

            //if (roles.Length > 1)
            //{
            //    roleNames = RolesHelper.GetRoles(roles[0]);

            //    for (var i = 1; i < roles.Length; i++)
            //    {
            //        roleNames += "," + roles[i];
            //    }
            //}

            Roles = "teamrole";
        }
    }
}
