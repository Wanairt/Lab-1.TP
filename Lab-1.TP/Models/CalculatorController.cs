using Microsoft.AspNetCore.Mvc;
using Lab_1.TP.Models;

namespace Lab_1.TP.Models
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ComparisonValue = 10.5;
            return View(new Calculator());
        }

        [HttpPost]
        public IActionResult Index(Calculator model, string button)
        {
            if (button == "clear")
            {
                model.Operand1Input = null;
                model.Operand2Input = null;
                model.Operation = null;
                model.Result = 0;
                ViewBag.ComparisonValue = 10.5;

                ModelState.Clear();

                return View(model);
            }

            if (ModelState.IsValid)
            {
                byte operand1;
                double operand2;
                bool isValid1 = byte.TryParse(model.Operand1Input, out operand1);
                bool isValid2 = double.TryParse(model.Operand2Input, out operand2);

                if (isValid1 && isValid2)
                {
                    model.Operand1 = operand1;
                    model.Operand2 = operand2;

                    switch (model.Operation)
                    {
                        case "+":
                            model.Result = operand1 + operand2;
                            break;
                        case "-":
                            model.Result = operand1 - operand2;
                            break;
                        case "*":
                            model.Result = operand1 * operand2;
                            break;
                        case "/":
                            if (operand2 != 0)
                                model.Result = operand1 / operand2;
                            else
                                model.Result = double.NaN;
                            break;
                        default:
                            model.Result = 0;
                            break;
                    }
                }
                else
                {
                    model.Result = double.NaN;
                }
            }
            ViewBag.ComparisonValue = 10.5;
            return View(model);
        }
    }
}
