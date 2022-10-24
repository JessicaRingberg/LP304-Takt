using Microsoft.AspNetCore.Authorization;

namespace LP304_Takt.Shared
{
    public class AuthorizedAttribute : AuthorizeAttribute
    {
        public AuthorizedAttribute(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("roles");
            Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        }
       
    }
}
