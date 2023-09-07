using System.Reflection;
using Xunit;

namespace Tests.RunLogic.Attributes;

public class HomeworkAttribute : FactAttribute
{
    private readonly Homeworks _number;

    public HomeworkAttribute(Homeworks number)
    {
        _number = number;
    }

    public override string? Skip => GetSkip(_number);

    internal static string? GetSkip(Homeworks number)
    {
        var hw = typeof(HomeworkProgressAttribute)
            .Assembly
            .GetCustomAttribute<HomeworkProgressAttribute>()?.Number;

        if (hw == null)
        {
            throw new InvalidOperationException("Test assembly must be marked with HomeworkProgressAttribute");
        }

        var assemblyNumber = (byte)hw.Value;
        return (byte)number <= assemblyNumber
            ? null
            : "Next Homeworks";
    }
}