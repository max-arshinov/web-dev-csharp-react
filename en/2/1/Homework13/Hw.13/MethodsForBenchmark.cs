using System.Diagnostics.CodeAnalysis;

namespace Hw13;

[ExcludeFromCodeCoverage]
public class MethodsForBenchmark
{
    public string Simple(string s) => s + s;
    public virtual string Virtual(string s) => s + s;
    public static string Static(string s) => s + s;
    public string Generic<T>(T s) => s!.ToString() + s;
    public string Dynamic(dynamic s) => s.ToString() + s;
    public string Reflection(string s) => s + s;
}