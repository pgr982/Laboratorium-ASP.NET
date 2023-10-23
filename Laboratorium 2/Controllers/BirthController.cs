using Laboratorium_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(Birth model)
        {
            if (model.IsValid())
            {
                int age = model.CalculateAge();
                ViewBag.Name = model.Name;
                ViewBag.Age = age;
                return View();
            }
            return View("Error");
        }
    }
}
