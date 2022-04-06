using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Caomei.Mvc
{
    public class AuthorizeJwtWithCookieAttribute : AuthorizeAttribute
    {
        public AuthorizeJwtWithCookieAttribute()
        {
            AuthenticationSchemes = $"{CookieAuthenticationDefaults.AuthenticationScheme},{JwtBearerDefaults.AuthenticationScheme}";
        }
    }
}