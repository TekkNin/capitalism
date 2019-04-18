using System.Security.Claims;
using System.Security.Principal;

namespace Capitalism.Web.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);

            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
