using Microsoft.AspNetCore.Mvc;

namespace DoorangTask.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
