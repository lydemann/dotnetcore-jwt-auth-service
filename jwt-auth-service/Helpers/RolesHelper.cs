using System;
using System.Collections.Generic;
using jwt_auth_service.Filters;

namespace jwt_auth_service.Helpers
{
    public class RolesHelper
    {
        internal static string GetRoles(Role role)
        {
            return String.Join(",", GetRolesFromAppSettings(role));
        }

        private static IEnumerable<string> GetRolesFromAppSettings(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
