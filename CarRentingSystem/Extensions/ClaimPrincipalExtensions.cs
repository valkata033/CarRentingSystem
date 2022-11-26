using System.Security.Claims;

namespace CarRentingSystem.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

    }
}
