using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;
using UserRoles.Data;

namespace MVC_Project.Controllers
{
    public class TestController : Controller
    {
        private readonly BakeryDbContext _context;

        public TestController(BakeryDbContext context)
        {
            _context = context;
        }

        public IActionResult TestConnection()
        {
            try
            {
                var canConnect = _context.Database.CanConnect();
                return Ok($"Database connection successful! CanConnect: {canConnect}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Connection failed: {ex.Message}");
            }
        }
    }
}