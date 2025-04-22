using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
    public class CheckoutController1 : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult Payment()
        {
            return View("Payment");
        }
        public IActionResult Review()
        {
            return View("Review");
        }
        public IActionResult Shipping()
        {
            return View("Shipping");
        }
    }
}
