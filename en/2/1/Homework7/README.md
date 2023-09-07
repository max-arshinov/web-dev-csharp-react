# Домашняя работа №7

## Reflection

### Теория
 1. Прочитать весь раздел Reflection (включая раздел Serialization) на [docs.microsoft.com](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection)
 2. Пройти весь раздел [Relflection на Ulearn](https://ulearn.me/course/basicprogramming2/Refleksiya_Klass_Type_8386b127-ea69-465d-87ba-24e08df9f6d2)
 3. Научиться работать с [html-формами](https://html5book.ru/html5-forms/)

### Вопросы к семинару
 1. Как создать объект тип которого неизвестен в момент компиляции, но известен в момент выполнения? Пример: ```var typeName = "MyClass"; var instance = new typeName();"```
 2. Что такое мета-информация? Какую мета-информацию можно получить с помощью reflection в .NET?
 3. В каких случаях разработчику следует использовать Reflection, а в каких не стоит? Какие факторы нужно учитывать?
 4. Почему если указать тип модели через ```@model``` Тип необязательно передавать экземпляр класса. А если не указывать, то нужно. Какой тип применяется, если не указать @model.

### Практика
 1. Написать аналоги extension-метода ```@Html.EditorForModel```. Должны поддерживаться типы данных: числа, строки, enum. Для enum’ов выводить дропдауны (тег select).
 2. Должны поддерживаться все наследники [ValidationAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationattribute?view=net-5.0): уже написанные и которые будут написаны в будущем.
 3. Если атрибут ```Display(Name=)``` не указан, то разбивать название свойства по CamelCase. Например FirstName => First Name