using System.Globalization;
using System.Net.Http.Json;
using Hw10.Dto;
using Hw10.ErrorMessages;
using Tests.RunLogic.Attributes;

namespace Tests.CSharp.Homework10;

public class IntegrationCalculatorControllerTests : IClassFixture<TestApplicationFactory>
{
    private readonly HttpClient _client;

    public IntegrationCalculatorControllerTests(TestApplicationFactory fixture)
    {
        _client = fixture.CreateClient();
    }

    [HomeworkTheory(Homeworks.HomeWork10)]
    [InlineData("10", "10")]
    [InlineData("2 + 3", "5")]
    [InlineData("(10 - 3) * 2", "14")]
    [InlineData("3 - 4 / 2", "1")]
    [InlineData("8 * (2 + 2) - 3 * 4", "20")]
    [InlineData("10 - 3 * (-4)", "22")]
    public async Task Calculate_CalculateExpression_Success(string expression, string result)
    {
        var response = await CalculateAsync(expression);
        Assert.True(response!.IsSuccess);
        Assert.Equal(result, response.Result.ToString(CultureInfo.InvariantCulture));
    }

    [HomeworkTheory(Homeworks.HomeWork10)]
    [InlineData(null, MathErrorMessager.EmptyString)]
    [InlineData("", MathErrorMessager.EmptyString)]
    [InlineData("10 + i", $"{MathErrorMessager.UnknownCharacter} i")]
    [InlineData("10 : 2", $"{MathErrorMessager.UnknownCharacter} :")]
    [InlineData("3 - 4 / 2.2.3", $"{MathErrorMessager.NotNumber} 2.2.3")]
    [InlineData("2 - 2.23.1 - 23", $"{MathErrorMessager.NotNumber} 2.23.1")]
    [InlineData("8 - / 2", $"{MathErrorMessager.TwoOperationInRow} - and /")]
    [InlineData("8 + (34 - + 2)", $"{MathErrorMessager.TwoOperationInRow} - and +")]
    [InlineData("4 - 10 * (/10 + 2)", $"{MathErrorMessager.InvalidOperatorAfterParenthesis} (/")]
    [InlineData("10 - 2 * (10 - 1 /)", $"{MathErrorMessager.OperationBeforeParenthesis} /)")]
    [InlineData("* 10 + 2", MathErrorMessager.StartingWithOperation)]
    [InlineData("10 + 2 -", MathErrorMessager.EndingWithOperation)]
    [InlineData("((10 + 2)", MathErrorMessager.IncorrectBracketsNumber)]
    [InlineData("(10 - 2))", MathErrorMessager.IncorrectBracketsNumber)]
    [InlineData("10 / 0", MathErrorMessager.DivisionByZero)]
    [InlineData("10 / (1 - 1)", MathErrorMessager.DivisionByZero)]
    public async Task Calculate_CalculateExpression_Error(string expression, string result)
    {
        var response = await CalculateAsync(expression);
        Assert.False(response!.IsSuccess);
        Assert.Equal(result, response.ErrorMessage);
    }

    private async Task<CalculationMathExpressionResultDto?> CalculateAsync(string expression)
    {
        var response = await _client.PostCalculateExpressionAsync(expression);
        return await response.Content.ReadFromJsonAsync<CalculationMathExpressionResultDto>();
    }
}