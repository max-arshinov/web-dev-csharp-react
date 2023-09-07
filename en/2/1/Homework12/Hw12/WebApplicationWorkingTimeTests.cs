using BenchmarkDotNet.Attributes;

namespace Hw12;

[MaxColumn]
[MinColumn]
public class WebApplicationWorkingTimeTests
{
	private HttpClient _cSharpClient = null!;
	private HttpClient _fSharpClient = null!;
		
	[GlobalSetup]
	public void SetUp()
	{
		_cSharpClient =  new TestApplicationFactoryCSharp().CreateClient();
		_fSharpClient =  new TestApplicationFactoryFSharp().CreateClient();
	}
	
	[Benchmark]
	public async Task PlusOperationTimeTestCSharp()
	{
		await SendRequestCSharp("1", "+", "2");
	}
		
	[Benchmark]
	public async Task SubtractionOperationTimeTestCSharp()
	{
		await SendRequestCSharp("3", "-", "2");
	}
		
	[Benchmark]
	public async Task MultiplicationOperationTimeTestCSharp()
	{
		await SendRequestCSharp("10", "*", "3");
	}

	[Benchmark]
	public async Task DivisionOperationTimeTestCSharp()
	{
		await SendRequestCSharp("20", "/", "10");
	}
	
	[Benchmark]
	public async Task PlusOperationTimeTestFSharp()
	{
		await SendRequestFSharp("1", "+", "2");
	}
		
	[Benchmark]
	public async Task SubtractionOperationTimeTestFSharp()
	{
		await SendRequestFSharp("3", "-", "2");
	}

	[Benchmark]
	public async Task MultiplicationOperationTimeTestFSharp()
	{
		await SendRequestFSharp("10", "*", "3");
	}

	[Benchmark]
	public async Task DivisionOperationTimeTestFSharp()
	{
		await SendRequestFSharp("20", "/", "10");
	}

	private async Task SendRequestCSharp(string v1, string operation, string v2)
	{
		await _cSharpClient.GetAsync($"/Calculator/Calculate?val1={v1}&operation={operation}&val2={v2}");
	}
		
	private async Task SendRequestFSharp(string v1, string operation, string v2)
	{
		await _fSharpClient.GetAsync($"/calculate?value1={v1}&operation={operation}&value2={v2}");
	}
}