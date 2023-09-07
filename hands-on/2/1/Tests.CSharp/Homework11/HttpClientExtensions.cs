namespace Tests.CSharp.Homework11;

public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage> PostCalculateExpressionAsync(this HttpClient client,
        string expression)
    {
        var stringContent = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "expression", expression }
        });

        var response = await client.PostAsync("/Calculator/CalculateMathExpression", stringContent);
        return response;
    }
}