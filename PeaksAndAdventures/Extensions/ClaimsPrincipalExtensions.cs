using System.Security.Claims;
using static PeaksAndAdventures.Common.Constants;

namespace PeaksAndAdventures.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }

        public static bool IsAmateurMountaineer(this ClaimsPrincipal user)
        {
            return user.IsInRole(AmateurMountaineerRole);
        }

        public static bool IsMountaineer(this ClaimsPrincipal user)
        {
            return user.IsInRole(MountaineerRole);
        }

        public static bool IsTourAgency(this ClaimsPrincipal user)
        {
            return user.IsInRole(TourAgencyRole);
        }
    }
}
