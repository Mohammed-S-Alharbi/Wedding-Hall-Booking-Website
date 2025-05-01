using Microsoft.AspNetCore.Mvc;
using WeddingHallBooking.Models;
using WeddingHallBooking.Data;

namespace WeddingHallBooking.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Save user to DB
                _context.Users.Add(model);
                _context.SaveChanges();

                // Redirect to login or homepage
                return RedirectToAction("Login");
            }

            return View(model);
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                // Set session (or cookie)
                HttpContext.Session.SetString("UserName", user.FullName);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
