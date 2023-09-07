using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Testing;
using Tests.RunLogic.Attributes;

namespace Tests.CSharp.Homework11;

public class CalculationTimeTests : IClassFixture<WebApplicationFactory<Hw11.Program>>
{
    private readonly HttpClient _client;

    public CalculationTimeTests(WebApplicationFactory<Hw11.Program> fixture)
    {
        _client = fixture.CreateClient();
    }

    [HomeworkTheory(Homeworks.HomeWork11)]
    [InlineData("2 + 3 + 4 + 6", 2990, 4000)]
    [InlineData("(2 * 3 + 3 * 3) * (5 / 5 + 6 / 6)", 2990, 4000)]
    [InlineData("(2 + 3) / 12 * 7 + 8 * 9", 3990, 5000)]
    private async Task CalculatorController_ParallelTest(string expression, long minExpectedTime, long maxExpectedTime)
    {
        var executionTime = await GetRequestExecutionTime(expression);

        Assert.True(executionTime >= minExpectedTime,
            UserMessagerForTest.WaitingTimeIsLess(minExpectedTime, executionTime));
        Assert.True(executionTime <= maxExpectedTime,
            UserMessagerForTest.WaitingTimeIsMore(maxExpectedTime, executionTime));
    }

    private async Task<long> GetRequestExecutionTime(string expression)
    {
        var watch = Stopwatch.StartNew();
        var response = await _client.PostCalculateExpressionAsync(expression);
        watch.Stop();
        response.EnsureSuccessStatusCode();
        return watch.ElapsedMilliseconds;
    }
}