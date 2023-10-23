using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_1
{
    public class HomeController: Controller
    {
        public enum Operator
        {
            Unknown, Add, Mul, Sub, Div
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Calculator(Operator op, double? a, double? b)
        {
           if(a == null || b == null) 
           {
                return View("Error"); 
           }

            ViewBag.op = op;
            ViewBag.a = a;
            ViewBag.b = b;

            switch(op)
            {
                case Operator.Unknown:
                    return View("Error");
                case Operator.Add:
                    ViewBag.result = a + b;
                    break;
                case Operator.Sub:
                    ViewBag.result = a - b;
                    break;
                case Operator.Mul:
                    ViewBag.result = a * b;
                    break;
                case Operator.Div:
                    ViewBag.result = a / b;
                    break;
            }
            return View();
        }
    }
}