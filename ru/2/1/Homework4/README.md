# Домашняя работа №4

## Функциональное программирование на F#

### Теория
 1. [Материалы лекции](https://docs.google.com/presentation/d/1wNLLm4mgdve8BnMIxaEajKHLV401-l_8PR0vg91UBqs/edit#slide=id.p100)
 2. [F# syntax in 60 seconds](https://fsharpforfunandprofit.com/posts/fsharp-in-60-seconds/)
 3. [Learning F#](https://fsharpforfunandprofit.com/learning-fsharp/)
 4. [Troubleshooting F#](https://fsharpforfunandprofit.com/troubleshooting-fsharp/)
 5. [F# for C# Programmers](https://fsharpforfunandprofit.com/csharp/)
 6. [Сила композиции](https://habr.com/ru/company/jugru/blog/553028/) (до монад не включительно)
 7. *Факультатив: [Теория категорий](https://ru.wikipedia.org/wiki/%D0%A2%D0%B5%D0%BE%D1%80%D0%B8%D1%8F_%D0%BA%D0%B0%D1%82%D0%B5%D0%B3%D0%BE%D1%80%D0%B8%D0%B9#%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5_%D0%BE%D0%BF%D1%80%D0%B5%D0%B4%D0%B5%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F_%D0%B8_%D1%81%D0%B2%D0%BE%D0%B9%D1%81%D1%82%D0%B2%D0%B0)*

### Вопросы к семинару
1. Назовите основные отличия функциональной парадигмы от ООП
2. Что такое функциональная композиция, какие преимущества она дает?
3. Дайте определение функциям высшего порядка (Higher Order Functions). Какую поддержку ФВП имеет C#?
4. Что такое ссылочная прозрачность (Referential transparency)? Чем важно это понятие?
5. Что такое каррирование и частичное применение? В чем разница между этими понятиями?
6. Почему ФП хорошо подходит для многопроцессорных и распределенных вычислений?
7. Какие типы данных называются “алгебраическими”? Почему они так называются? Какие алгебраические типы данных поддерживаются в C# и F#? Какие только в F#?
8. *Вопрос на +1 на семинаре: сравните Discriminated Unions в F#, [*Sealed классы*](https://kotlinlang.org/docs/sealed-classes.html), [Enum классы](https://kotlinlang.org/docs/enum-classes.html) в Kotlin. В чем они похожи? В чем различие?*

### Практика
1. Переписать калькулятор на F#
2. Все еще должно оставаться 100% покрытие. Проще всего посмотреть как компилируются F#-функции в IL. Существующие тесты нужно будет отредактировать совсем чуть-чуть.
3. Тесты можете оставить на C# или переписать на F# (по желанию)