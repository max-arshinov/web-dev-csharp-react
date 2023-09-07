# Домашняя работа №2

## Версии и устройство .NET

### Теория
.NET &amp; C# history
 1. [The journey to one .net | .Net 5 and beyond | Microsoft build 2020](https://www.youtube.com/watch?v=oyF6RGKlvi8)
 2. [The history of C#](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history)
 3. [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-1-0)
 
CIL
 
 4. [CIL programming tutorial – The Basics Part I](https://dolinkamark.wordpress.com/2015/10/21/cil-programming-tutorial-the-basics/)
 5. [CIL programming tutorial – The Basics Part II](https://dolinkamark.wordpress.com/2016/04/24/cil-programming-tutorial-the-basics-part-ii/)
 6. [What can you do in MSIL that you cannot do in C# or VB.NET?](https://stackoverflow.com/questions/541936/what-can-you-do-in-msil-that-you-cannot-do-in-c-sharp-or-vb-net)

JIT

 7. [The RyuJIT transition is complete](https://devblogs.microsoft.com/dotnet/the-ryujit-transition-is-complete/)
 8. [Егор Богатов — Как устроен JIT-компилятор в CoreCLR](https://www.youtube.com/watch?v=H1ksFnLjLoY)
 9. [Tiered compilation](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#tiered-compilation)
 10. [Choosing the right defaults for tiered compilation](https://github.com/dotnet/runtime/issues/12515) 

### Вопросы к семинару
1. В чем различие между .NET Framework, .NET Core, .NET 5, .NET 6 и .NET Standard?
2. Какие виды приложений можно разрабатывать на C#, начиная с .NET 5?
3. С каким языком работает JIT?
4. Зачем .NET-разработчику уметь читать CIL?
5. Что исполняет CLR?
6. Что такое CTS (Common Type System). Что означает, что код CLS-совместим?
7. Можно ли подключить к C#-сборке, сборку, написанную на другом managed-языке, если сборка не CLS-совместима?
8. Объясните первокурснику как работает JIT-компиляция в .NET не дольше, чем за 3 минуты.
9. Что такое Tiered compilation? В чем заключается компромисс JIT-компиляции?

### Практика
1. Переписать методы Calculate и Parse на IL, используя тип проекта Microsoft.NET.Sdk.IL
2. Main и тесты могут остаться на C#