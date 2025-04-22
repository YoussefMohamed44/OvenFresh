using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View("Login");
        }
        public IActionResult Register()
        {
            return View("Register");
        }
        public IActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }
        public IActionResult ResetPassword()
        {
            return View("ResetPassword");
        }
    }
}
