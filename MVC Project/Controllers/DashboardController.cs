using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Addresses()
        {
            return View("Addresses");
        }

        public IActionResult Orders()
        {
            return View("Orders");
        }

        public IActionResult Reviews()
        {
            return View("Reviews");
        }

    }
}
