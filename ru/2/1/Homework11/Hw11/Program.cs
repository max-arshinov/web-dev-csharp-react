using System.Diagnostics.CodeAnalysis;
using Hw11.Configuration;
using Hw11.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddMathCalculator();
builder.Services.AddTransient<IExceptionHandler, ExceptionHandler>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculator}/{action=Calculator}/{id?}");

app.Run();

namespace Hw11
{
    [ExcludeFromCodeCoverage]
    public partial class Program { }
}