# Домашняя работа №10

## IQueryable IQueryProvider

### Теория
 1. [IEnumerable и IQueryable в Entity Framework](https://metanit.com/sharp/entityframework/1.4.php)
 2. [Принципы работы IQueryable и LINQ-провайдеров данных](https://habr.com/ru/post/256821/)
 3. [Реализация своих поставщиков запросов](https://www.youtube.com/watch?v=QVdfx51mlao&feature=youtu.be) ([репозиторий](https://github.com/anetegithub/Linq.GraphQL))

### Факультатив:
1. Пример написания [LINQ-провайдера для файловой системы](https://jacopretorius.net/2010/01/implementing-a-custom-linq-provider.html)
2. [Объяснение Expression.Quote](https://stackoverflow.com/questions/3716492/what-does-expression-quote-do-that-expression-constant-can-t-already-do/3753382#3753382)
3. [Пример реализации QueryProvider’а для старой версии .NET](https://weblogs.asp.net/dixin/understanding-linq-to-sql-10-implementing-linq-to-sql-provider)

### Практика
1. Добавить кеширование расчетов. Доступ из кеша не должен идти без искусственной задержки в 1000мс 
2. Использовать паттерн “[декоратор](https://refactoring.guru/ru/design-patterns/decorator)” для кеширующего калькулятора
3. Использовать [миграции](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) для создания таблицы с кешем

### Задача на доп. баллы
1. Заменить реализации IQueryable и IQueryProvider с Entity Framework на самописную
