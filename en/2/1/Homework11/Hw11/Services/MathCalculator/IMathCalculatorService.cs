namespace Hw11.Services.MathCalculator;

public interface IMathCalculatorService
{ 
    Task<double> CalculateMathExpressionAsync(string? expression);
}