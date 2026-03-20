using Microsoft.AspNetCore.Mvc;

namespace Auth_Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
