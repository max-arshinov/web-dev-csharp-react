using System.Diagnostics.CodeAnalysis;
using Hw11.Dto;
using Hw11.Exceptions;
using Hw11.Services.MathCalculator;
using Microsoft.AspNetCore.Mvc;

namespace Hw11.Controllers;

public class CalculatorController : Controller
{
    private readonly IMathCalculatorService _mathCalculatorService;
    private readonly IExceptionHandler _exceptionHandler;

    public CalculatorController(IMathCalculatorService mathCalculatorService, IExceptionHandler exceptionHandler)
    {
        _mathCalculatorService = mathCalculatorService;
        _exceptionHandler = exceptionHandler;
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
        try
        {
            var result = await _mathCalculatorService.CalculateMathExpressionAsync(expression);
            return Json(new CalculationMathExpressionResultDto(result));
        }
        catch (Exception e)
        {
            _exceptionHandler.HandleException(e);
            return Json(new CalculationMathExpressionResultDto(e.Message));
        }
    }
}