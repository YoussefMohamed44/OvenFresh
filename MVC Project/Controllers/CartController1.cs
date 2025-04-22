using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
    public class CartController1 : Controller
    {
        public IActionResult Dipsplay()
        {
            return View("index");
        }
    }
}
