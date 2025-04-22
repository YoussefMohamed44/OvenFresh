using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
    public class ProductController1 : Controller
    {
        public IActionResult Index()
        {
            return View("index");
        }

        public IActionResult Details()
        {
            return View("Details");
        }

    }
}
