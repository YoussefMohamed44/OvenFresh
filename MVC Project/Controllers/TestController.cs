using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;

namespace MVC_Project.Controllers
{
    public class TestController : Controller
    {
        private readonly BakeryDbContext _context;

        public TestController(BakeryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}
