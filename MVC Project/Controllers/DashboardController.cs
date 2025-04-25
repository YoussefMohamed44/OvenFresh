using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Admin()
        {
            return View("Admin");
        }

        public IActionResult User()
        {
            return View("User");
        }

    }
}
