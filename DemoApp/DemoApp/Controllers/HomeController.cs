using System.Diagnostics;
using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new CalculatorViewModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorViewModel model)
        {
            switch (model.Action)
            {
                case "Add":
                    model.Result = model.Number1 + model.Number2;
                    break;
                case "Subtract":
                    model.Result = model.Number1 - model.Number2;
                    break;
                case "Multiply":
                    model.Result = model.Number1 * model.Number2;
                    break;
                case "Divide":
                    // Simple check to prevent crash
                    model.Result = model.Number2 != 0 ? model.Number1 / model.Number2 : 0;
                    break;
            }
            return View(model);
        }
    }
}