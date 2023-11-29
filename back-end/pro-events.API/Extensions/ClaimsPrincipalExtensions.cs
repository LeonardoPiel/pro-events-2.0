using System.Security.Claims;

namespace pro_events.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {

        /***
         * As ClaimsType utilizadas aqui são as mesmas configuradas no arquivo TokenService.
         */
        public static string GetUserName(this ClaimsPrincipal user) => user.FindFirst(ClaimTypes.Name)?.Value;
        public static string GetUserID(this ClaimsPrincipal user) => user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public static int GetUserIdAsInt(this ClaimsPrincipal user) => int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}
