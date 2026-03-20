using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Auth_Demo.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {

            var role = "Admin" == "Admin" ? "Admin" : "User";
            if ((username == "admin") && (password == "123") || (username == "user") && (password == "1234")) {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role , role)
                };
                var Identity = new ClaimsIdentity(claims,"MyAuthCookie");

                var Principal = new ClaimsPrincipal(identity);
                
                 await HttpContext.SignInAsync();
                return RedirectToAction("Index", "Home");
            }


            ViewBag.Error = "Invalid Credentials";
            return View();
        }
    }
}
