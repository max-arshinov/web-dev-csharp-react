namespace Hw1;

public static class Calculator
{
    public static double Calculate(double value1, CalculatorOperation operation, double value2)
    {
        return operation switch
        {
            CalculatorOperation.Plus => value1 + value2,
            CalculatorOperation.Minus => value1 - value2,
            CalculatorOperation.Multiply => value1 * value2,
            CalculatorOperation.Divide => value1 / value2,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}