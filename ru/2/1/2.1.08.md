# Домашняя работа №8 

## Dependency Inversion

### Теория
1. [Инверсия зависимостей](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion)
2. Встроенные в ASP.NET Core механизмы [внедрения зависимостей](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)
3. [From dependency injection to dependency rejection](https://www.youtube.com/watch?v=xG5qP5AWQws) ([расшифровка](https://habr.com/ru/company/jugru/blog/545482/))
4. О вреде [ServiceLocator](https://habr.com/ru/post/270005/)

### Вопросы к семинару
1. Какую проблему решает техника внедрения зависимостей?
2. Какое ключевое слово не потребуется использовать, если все зависимости будут создаваться с помощью IOC-контейнера?
3. Как вы поняли фразу “внедрение зависимостей - это просто претенциозный способ передачи параметров”?
4. Когда следует самостоятельно реализовать Singleton, а когда использовать соответствующий lifestyle, если ваше приложение построено на основе IOC-контейнера?
5. В чем вред Service Locator?
6. Какой scope существует по-умолчанию в ASP.NET Core приложении?
7. Как “дотянуться” до scoped-зависимостей в таком коде?
   ``      Task.Run(() => {  
   // здесь нужны scoped-зависимости  
   });``


### Практика
1. Оформить калькулятор в виде класса, передать класс калькулятора в [качестве зависимости](https://stackoverflow.com/questions/52204022/how-to-do-di-in-asp-net-core-middleware). Допустимо использовать Giraffe, ASP.NET Core Controller или самописный Middleware. Giraffe и ASP.NET Core - это тоже Middleware.
2. Написать тесты, используя [XUnit Theory](https://hamidmosalla.com/2017/02/25/xunit-theory-working-with-inlinedata-memberdata-classdata/) и [интеграционные тесты](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0) на C#