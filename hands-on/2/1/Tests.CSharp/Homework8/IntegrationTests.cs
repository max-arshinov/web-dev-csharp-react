using Hw8.Calculator;
using Microsoft.AspNetCore.Mvc.Testing;
using Tests.RunLogic.Attributes;

namespace Tests.CSharp.Homework8;

public class IntegrationTests : IClassFixture<WebApplicationFactory<Hw8.Program>>
{
    private readonly HttpClient _client;
    private readonly string _url = "https://localhost:7008";

    public IntegrationTests(WebApplicationFactory<Hw8.Program> fixture)
    {
        _client = fixture.CreateClient();
    }

    [HomeworkTheory(Homeworks.HomeWork8)]
    [InlineData("9", Operation.Plus, "4", "13")]
    [InlineData("1000", Operation.Minus, "4.53", "995.47")]
    [InlineData("63", Operation.Divide, "21", "3")]
    [InlineData("56", Operation.Multiply, "7", "392")]
    public async Task Calculate_CorrectArguments_CorrectResultReturned(string val1, Operation operation, string val2,
        string expected)
    {
        var response =
            await _client.GetAsync($"{_url}/Calculator/Calculate?val1={val1}&operation={operation}&val2={val2}");
        var actual = await response.Content.ReadAsStringAsync();
        Assert.Equal(expected, actual);
    }

    [HomeworkTheory(Homeworks.HomeWork8)]
    [InlineData("a", Operation.Plus, "4", Messages.InvalidNumberMessage)]
    [InlineData("1000", Operation.Minus, "b", Messages.InvalidNumberMessage)]
    [InlineData("63", Operation.Invalid, "3", Messages.InvalidOperationMessage)]
    [InlineData("63", Operation.Divide, "0", Messages.DivisionByZeroMessage)]
    public async Task Calculate_IncorrectArguments_ExceptionStringReturned(string val1, Operation operation,
        string val2, string expected)
    {
        var response =
            await _client.GetAsync($"{_url}/Calculator/Calculate?val1={val1}&operation={operation}&val2={val2}");
        var actual = await response.Content.ReadAsStringAsync();
        Assert.Equal(expected, actual);
    }

    [HomeworkTheory(Homeworks.HomeWork8)]
    [InlineData("1", "qwerty", "4", Messages.InvalidOperationMessage)]
    public async Task Calculate_UnavailableOperation_InvalidOperationMessageReturned(string val1, string operation,
        string val2, string expected)
    {
        var response =
            await _client.GetAsync($"{_url}/Calculator/Calculate?val1={val1}&operation={operation}&val2={val2}");
        var actual = await response.Content.ReadAsStringAsync();
        Assert.Equal(expected, actual);
    }
}