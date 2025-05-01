//using Microsoft.AspNetCore.Mvc;

//namespace WeddingHallBooking.Controllers
//{
//    public class HomeController : Controller
//    {
//        public IActionResult Index() => View();
//        public IActionResult About() => View();
//        public IActionResult Booking() => View();
//        public IActionResult Contact() => View();
//        public IActionResult Register() => View();
//        public IActionResult Login() => View();
//        public IActionResult Mybookings() => View();
//    }
//}













//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using System.Linq;
//using WeddingHallBooking.Data;      // replace with your actual namespace
//using WeddingHallBooking.Models;    // replace with your actual namespace

//namespace WeddingHallBooking.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public HomeController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: /
//        public IActionResult Index() => View();

//        // Other static pages
//        public IActionResult About() => View();
//        public IActionResult Booking() => View();
//        public IActionResult Contact() => View();
//        public IActionResult Mybookings() => View();
//        public IActionResult Venues() => View();

//        // GET: /Home/Register
//        public IActionResult Register()
//        {
//            return View();
//        }

//        // POST: /Home/Register
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Register(User user)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Users.Add(user);
//                _context.SaveChanges();
//                TempData["Success"] = "Registration successful. Please login.";
//                return RedirectToAction("Login");
//            }
//            return View(user);
//        }

//        // GET: /Home/Login
//        public IActionResult Login()
//        {
//            return View();
//        }

//        // POST: /Home/Login
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Login(string email, string password)
//        {
//            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
//            if (user != null)
//            {
//                HttpContext.Session.SetString("UserName", user.FullName);
//                return RedirectToAction("Index");
//            }

//            ViewBag.Error = "Invalid email or password";
//            return View();
//        }

//        public IActionResult Logout()
//        {
//            HttpContext.Session.Clear();
//            return RedirectToAction("Index");
//        }
//    }
//}



using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using WeddingHallBooking.Data;
using WeddingHallBooking.Models;

namespace WeddingHallBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View();
        public IActionResult About() => View();
        public IActionResult Contact() => View();
        public IActionResult Venues() => View();

        // GET: Booking form
        public IActionResult Booking()
        {
            return View();
        }

        // POST: Save booking from form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Booking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                TempData["Success"] = "?? ????? ?????!";
                return RedirectToAction("Mybookings");
            }

            return View(booking);
        }

        // GET: Show all bookings
        public IActionResult Mybookings()
        {
            var allBookings = _context.Bookings.ToList();
            return View(allBookings);
        }

        // Register & Login

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                TempData["Success"] = "Registration successful. Please login.";
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.FullName);
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
