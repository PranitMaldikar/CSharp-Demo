using System.Linq;
using System.Web.Mvc;
using ChatbotApp.Models;

namespace ChatbotApp.Controllers
{
    public class AccountController : Controller
    {
        // In-memory user list for demonstration
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "password" }
        };

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (existingUser != null)
            {
                Session["UserId"] = existingUser.Id;
                Session["Username"] = existingUser.Username;
                return RedirectToAction("Index", "Chat");
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(user);
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
