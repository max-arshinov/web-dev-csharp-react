# Домашняя работа №9 

## Expression Trees

### Теория
1. [C# programming. Lesson 15. Expression tree](https://www.youtube.com/watch?v=a9L22U4XWN0&ab_channel=%D0%9F%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5-%D1%8D%D1%82%D0%BE%D0%BF%D1%80%D0%BE%D1%81%D1%82%D0%BE)
2. [Деревья выражений в enterprise](https://habr.com/ru/company/jugru/blog/423891/) ([репозиторий с примерами](https://github.com/max-arshinov/Beyond-LINQ-Using-Expression-Trees-in-.NET))
3. [AutoFilterer](https://github.com/enisn/AutoFilterer)
4. [AutoMapper](https://automapper.org/), [Mapster](https://github.com/MapsterMapper/Mapster)
5. *Факультатив:* [*Async as surrogate IO*](https://blog.ploeh.dk/2016/04/11/async-as-surrogate-io/)

### Вопросы к семинару
 1. В чем отличие `IQueryable<T>` от `IEnumerable<T>`?
 2. Назовите типы лямбда-выражений в методах `IQueryable.Where` и `IEnumerable.Where`
 3. Как от Expression перейти к делегату?
 4. Как от делегата перейти к `Expression`?
 5. Назовите основные сценарии применения Expressions в прикладной разработке.
 6. Почему нужно отказаться от использования `Activator.CreateInstance` и нужно ли?
 
### Практика
 1. Изменить входные параметры калькулятора - передавать строку с выражением, например (2+3) / 12 * 7 + 8 * 9, преобразовывать строку к Expression Tree
 2. Для разбора дерева использовать [ExpressionVisitor](https://docs.microsoft.com/en-us/dotnet/api/system.linq.expressions.expressionvisitor?view=netcore-3.1)
 3. Все операции, которые можно выполнить параллельно выполнять параллельно. Собирать результат с помощью [Task.WhenAll](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.whenall?view=netcore-3.1). (В докладе Дмитрия Иванова про Async/Await есть подсказка как запрограммировать такой алгоритм)
 4. Клиент на C#, интеграционные тесты
 5. Для тестирования || запросов добавить искусственную задержку в 1000мс на бекенде
 #### Пример плана выполнения
    2 + 3  
    ----- / 12  
    ---------- * 7  
    8 * 9  
    -------------- +
### Задание на дополнительные баллы
1.  Создать `AsyncEitherBuilder`, оформить клиент на F#, работающий на основе `AsyncEitherBuilder`