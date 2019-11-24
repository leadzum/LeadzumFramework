using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Leadzum.Framework.Mvc.Utility
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetDisplayName(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var displayName = string.Empty;
            if (user.Identity.IsAuthenticated)
            {
                var claim = user.FindFirstValue("DisplayName");
                if (claim != null)
                {
                    displayName = claim;
                }
            }
            return displayName;
        }

        public static T GetUserId<T>(this IPrincipal user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var userId = ((ClaimsPrincipal)user).FindFirstValue(ClaimTypes.NameIdentifier);

            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(userId, typeof(T));
            }
            else if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
            {
                return userId != null ? (T)Convert.ChangeType(userId, typeof(T)) : (T)Convert.ChangeType(0, typeof(T));
            }
            else
            {
                throw new Exception("Invalid type provided");
            }
        }


        public static int GetUserTypeId(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            int userTypeId = -1;
            if (user.Identity.IsAuthenticated)
            {
                var claim = user.FindFirstValue("UserTypeId");
                if (claim != null)
                {
                    int.TryParse(claim, out userTypeId);
                }
            }
            return userTypeId;
        }

        public static int GetUserRoleId(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            int roleId = -1;
            if (user.Identity.IsAuthenticated)
            {
                var claim = user.FindFirstValue("RoleId");
                if (claim != null)
                {
                    int.TryParse(claim, out roleId);
                }
            }
            return roleId;
        }
    }
}
