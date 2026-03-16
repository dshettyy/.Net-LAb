using Microsoft.AspNetCore.Mvc;
using StudentMVC.Models;

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(StudentViewModel student)
        {
            return View(student);
        }
    }
}
