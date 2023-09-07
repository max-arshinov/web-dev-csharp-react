using System.Diagnostics.CodeAnalysis;
using Hw9.Dto;
using Hw9.Services.MathCalculator;
using Microsoft.AspNetCore.Mvc;

namespace Hw9.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IMathCalculatorService _mathCalculatorService;

        public CalculatorController(IMathCalculatorService mathCalculatorService)
        {
            _mathCalculatorService = mathCalculatorService;
        }
        
        [HttpGet]
        [ExcludeFromCodeCoverage]
        public IActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<CalculationMathExpressionResultDto>> CalculateMathExpression(string expression)
        {
            var result = await _mathCalculatorService.CalculateMathExpressionAsync(expression);
            return Json(result);
        }
    }
}