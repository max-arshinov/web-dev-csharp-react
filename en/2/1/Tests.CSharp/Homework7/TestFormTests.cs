using Hw7.ErrorMessages;
using Hw7.Models.ForTests;
using Microsoft.AspNetCore.Mvc.Testing;
using Tests.CSharp.Homework7.Shared;
using Tests.RunLogic.Attributes;

namespace Tests.CSharp.Homework7;

public class TestFormTests : IClassFixture<WebApplicationFactory<Hw7.Program>>
{
    private readonly HttpClient _client;
    private readonly string _url = "/Test/TestModel";

    public TestFormTests(WebApplicationFactory<Hw7.Program> fixture)
    {
        _client = fixture.CreateClient();
    }

    [HomeworkTheory(Homeworks.HomeWork7)]
    [InlineData("FirstName", "First Name")]
    [InlineData("Age", "Age")]
    [InlineData("A", "A")]
    public async Task GetTestForm_PropsWithoutDisplayAttr_CamelCaseSplit(string propertyName, string expected)
    {
        //arrange
        var response = await TestHelper.GetFormHtml(_client, _url);

        //act
        var actual = TestHelper.GetPropertyNameFromLabel(response, propertyName);

        //assert
        Assert.Equal(expected, actual);
    }

    [HomeworkTheory(Homeworks.HomeWork7)]
    [InlineData("FirstName", Messages.RequiredMessage)]
    [InlineData("LastName", "")]
    [InlineData("MiddleName", Messages.RequiredMessage)]
    [InlineData("Age", $"Age {Messages.RangeMessage}")]
    public async Task PostEmptyTestForm_CheckForRequiredProperty_EveryPropertyIsRequiredExceptLastName(
        string propertyName,
        string expected)
    {
        //arrange
        var model = new BaseModel();
        var response = await TestHelper.SendForm(_client, _url, model);

        //act
        var actual = TestHelper.GetValidationMessageFromSpan(response, propertyName);

        //assert
        Assert.Equal(expected, actual);
    }

    [HomeworkTheory(Homeworks.HomeWork7)]
    [InlineData("FirstName", $"First Name {Messages.MaxLengthMessage}")]
    [InlineData("LastName", $"Last Name {Messages.MaxLengthMessage}")]
    [InlineData("MiddleName", "")]
    public async Task PostInvalidTestForm_CheckForMaxLengthValidation_EveryStringPropertyIsValidatedExceptMiddleName(
        string propertyName,
        string expected)
    {
        //arrange
        var model = new BaseModel
            { FirstName = TestHelper.LongString, LastName = TestHelper.LongString, MiddleName = TestHelper.LongString };
        var response = await TestHelper.SendForm(_client, _url, model);

        //act
        var actual = TestHelper.GetValidationMessageFromSpan(response, propertyName);

        //assert";
        Assert.Equal(expected, actual);
    }
}