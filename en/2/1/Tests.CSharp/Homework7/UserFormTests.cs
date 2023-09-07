using Hw7.ErrorMessages;
using Hw7.Models;
using Hw7.Models.ForTests;
using Microsoft.AspNetCore.Mvc.Testing;
using Tests.CSharp.Homework7.Shared;
using Tests.RunLogic.Attributes;

namespace Tests.CSharp.Homework7;

public class UserFormTests : IClassFixture<WebApplicationFactory<Hw7.Program>>
{
    private readonly HttpClient _client;
    private readonly string _url = "/Home/UserProfile";

    public UserFormTests(WebApplicationFactory<Hw7.Program> fixture)
    {
        _client = fixture.CreateClient();
    }

    [HomeworkTheory(Homeworks.HomeWork7)]
    [InlineData("FirstName", "text")]
    [InlineData("LastName", "text")]
    [InlineData("MiddleName", "text")]
    [InlineData("Age", "number")]
    public async Task EditorForModel_CheckInputTypes_CorrectTypes(string propertyName, string expectedType)
    {
        //arrange
        var response = await TestHelper.GetFormHtml(_client, _url);

        //act
        var actual = TestHelper.GetInputTypeForProperty(response, propertyName);

        //assert
        Assert.Equal(expectedType, actual);
    }

    [Homework(Homeworks.HomeWork7)]
    public async Task EditorForModel_CheckEnumTypeForSex_CorrectType()
    {
        //arrange
        var response = await TestHelper.GetFormHtml(_client, _url);

        //act
        var actual = TestHelper.TryGetSelect(response, "Sex");

        //assert
        Assert.True(actual);
    }

    [HomeworkTheory(Homeworks.HomeWork7)]
    [InlineData("FirstName", "Имя")]
    [InlineData("LastName", "Фамилия")]
    [InlineData("MiddleName", "Отчество")]
    [InlineData("Age", "Возраст")]
    [InlineData("Sex", "Пол")]
    public async Task GetUserForm_ModelWithDisplayAttr_CorrectLabelsForProperties(string propertyName, string expected)
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
    [InlineData("LastName", Messages.RequiredMessage)]
    [InlineData("MiddleName", Messages.RequiredMessage)]
    [InlineData("Age", $"Age {Messages.RangeMessage}")]
    public async Task PostEmptyUserForm_ModelWithRequiredProps_EveryPropertyIsRequired(string propertyName,
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
    [InlineData("MiddleName", $"Middle Name {Messages.MaxLengthMessage}")]
    [InlineData("Age", "")]
    public async Task PostUserForm_ModelWithRequiredProps_EveryPropertyIsValidated(string propertyName,
        string expected)
    {
        //arrange
        var model = new BaseModel
        {
            FirstName = TestHelper.LongString, LastName = TestHelper.LongString, MiddleName = TestHelper.LongString,
            Age = 15, Sex = Sex.Male
        };
        var response = await TestHelper.SendForm(_client, _url, model);

        //act
        var actual = TestHelper.GetValidationMessageFromSpan(response, propertyName);

        //assert
        Assert.Equal(expected, actual);
    }
}