using LogisticsTrackingSystem.Data;
using LogisticsTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LogisticsTrackingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Register page
        public IActionResult Register()
        {
            return View();
        }
        // GET: Login page
         public IActionResult Login()
        {
            return View();
       }

       // POST: Login user
        [HttpPost]
        public IActionResult Login(
             string email,
            string password)
       {
             var user = _context.Users
                 .FirstOrDefault(x =>
                     x.Email == email &&
                     x.Password == password);

            if (user != null)
            {
                 HttpContext.Session.SetString(
                     "Username",
                     user.Username);

                HttpContext.Session.SetString(
                     "Role",
                    user.Role);

                return RedirectToAction(
                     "Index",
                    "Home");
            }

             ViewBag.Error =
                 "Invalid email or password";

            return View();
      }

        // POST: Save user
        [HttpPost]
        public async Task<IActionResult> Register(
            User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                return RedirectToAction(
                    "Index",
                    "Home");
            }



            return View(user);
        }
        // Logout user
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(
                "Login",
                "Account");
        }
    }
}