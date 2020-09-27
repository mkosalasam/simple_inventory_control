using Microsoft.AspNetCore.Mvc;

namespace InventoryControlClient.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
