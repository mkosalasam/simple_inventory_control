using Microsoft.AspNetCore.Http;

namespace InventoryControlClient.Utilities
{
    public static class UserState
    {
        public static bool IsLoggedIn(HttpContext context)
        {
            var user = context.User;
            if (user?.Identity != null && user.Identity.IsAuthenticated)
            {
                return true;
            }

            return false;
        }
    }
}
