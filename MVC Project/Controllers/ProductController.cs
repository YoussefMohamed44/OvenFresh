using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MVC_Project.Data;
using MVC_Project.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Data;

namespace MVC_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly BakeryDbContext _context;

        public ProductController(BakeryDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var products = await _context.Products.ToListAsync();
            if (!searchString.IsNullOrEmpty())
            {
                products = _context.Products.Where(p => p.Name.Contains(searchString)).ToList();
                return View("index", products);
            }

            return View("index", products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Include(p => p.Reviews)
                    .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        public string IndexAJAX(string searchString)
        {
            string wrapString = "%" + searchString + "%";
            var prod = _context.Products.FromSqlInterpolated(
                $"SELECT * FROM Products WHERE Name LIKE {wrapString}"
            ).ToList();
            string json = JsonConvert.SerializeObject(prod);
            return json;
        }
    }
}