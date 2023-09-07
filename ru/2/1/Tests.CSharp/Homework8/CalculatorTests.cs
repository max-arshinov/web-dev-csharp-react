using Hw8.Calculator;
using Tests.RunLogic.Attributes;

namespace Tests.CSharp.Homework8;

public class CalculatorTests
{
    [HomeworkTheory(Homeworks.HomeWork8)]
    [InlineData(1, 2, 3)]
    [InlineData(-5.5, 2, -3.5)]
    [InlineData(10, 24.3, 34.3)]
    public void Plus_TwoNumbers_ReturnSum(double val1, double val2, double expResult)
    {
        //arrange
        ICalculator calculator = null;

        //act
        var actual = calculator.Plus(val1, val2);

        //assert
        Assert.Equal(actual, expResult);
    }

    [HomeworkTheory(Homeworks.HomeWork8)]
    [InlineData(1, 2, -1)]
    [InlineData(-5.5, 2, -7.5)]
    [InlineData(10, -24.3, 34.3)]
    public void Minus_TwoNumbers_ReturnDiff(double val1, double val2, double expResult)
    {
        //arrange
        ICalculator calculator = null;

        //act
        var actual = calculator.Minus(val1, val2);

        //assert
        Assert.Equal(actual, expResult);
    }

    [HomeworkTheory(Homeworks.HomeWork8)]
    [InlineData(1, 2, 2)]
    [InlineData(-5.5, 2, -11)]
    [InlineData(0, 24.3, 0)]
    public void Multiply_TwoNumbers_ReturnMultiplication(double val1, double val2, double expResult)
    {
        //arrange
        ICalculator calculator = null;

        //act
        var actual = calculator.Multiply(val1, val2);

        //assert
        Assert.Equal(actual, expResult);
    }

    [HomeworkTheory(Homeworks.HomeWork8)]
    [InlineData(1, 2, 0.5)]
    [InlineData(-5, 2, -2.5)]
    public void Divide_TwoNumbers_ReturnQuotient(double val1, double val2, double expResult)
    {
        //arrange
        ICalculator calculator = null;

        //act
        var actual = calculator.Divide(val1, val2);

        //assert
        Assert.Equal(actual, expResult);
    }

    [Homework(Homeworks.HomeWork8)]
    public void DivideByZero_ThrowsInvalidOperationException()
    {
        ICalculator calculator = null;

        //act + assert
        Assert.Throws<InvalidOperationException>(() => { calculator.Divide(1, 0); });
    }
}