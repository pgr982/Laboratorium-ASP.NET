using Laboratorium_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_2.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public enum Operators
        {
            Unknown, Add, Mul, Sub, Div
        }

        //public IActionResult Result(Operators op, double? a, double? b)
        //{
        //    if (a == null || b == null)
        //    {
        //        return View("Error");
        //    }

        //    ViewBag.op = op;
        //    ViewBag.a = a;
        //    ViewBag.b = b;

        //    switch (op)
        //    {
        //        case Operators.Unknown:
        //            return View("Error");
        //        case Operators.Add:
        //            ViewBag.result = a + b;
        //            break;
        //        case Operators.Sub:
        //            ViewBag.result = a - b;
        //            break;
        //        case Operators.Mul:
        //            ViewBag.result = a * b;
        //            break;
        //        case Operators.Div:
        //            ViewBag.result = a / b;
        //            break;
        //    }
        //    return View();
        //}

        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }

        //public IActionResult Result(Calculator model)
        //{
        //    if (!model.IsValid())
        //    {
        //        return View("Error");
        //    }
        //    return View(model);
        //}

        public IActionResult Form()
        {
            return View();
        }
    }
}
