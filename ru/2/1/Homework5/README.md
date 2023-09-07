# Домашняя работа №5

## Монадки

*В Java-команду приходит программист и предлагает переписать все на Scala. Команда посовещавшись
отвечает: “забирай свои монадки и проваливай отсюда…”*

### Теория
 1. [Материалы лекции](https://docs.google.com/presentation/d/1wNLLm4mgdve8BnMIxaEajKHLV401-l_8PR0vg91UBqs/edit#slide=id.p100)
 2. [Сила композиции](https://habr.com/ru/company/jugru/blog/553028/) (монады)
 3. [Функторы, аппликативные функторы и монады в картинках, без картинок](https://habr.com/ru/post/183150/)
 4. [Understanding map and apply, Understanding bind, Using the core functions in practice](https://fsharpforfunandprofit.com/posts/elevated-world/)
 5. [Composition with an Either computation expression](https://blog.ploeh.dk/2016/03/21/composition-with-an-either-computation-expression/)
 6. [Железнодорожно-ориентированное программирование](https://habr.com/ru/post/339606/)  ([расширенная версия с >=>](https://fsharpforfunandprofit.com/posts/recipe-part2/))

### Вопросы к семинару
1. Выберите одно слово, заканчивающиеся на *-able* или *-емый/емая*, чтобы описать сущность монад 
2. Что общего у монадических типов Option, Seq, Task? Чем они отличаются? 
3. С помощью какой функции может быть выражена функциональная композиция для монадических типов? 
4. Как с помощью bind и return получить map? 
5. Как с помощью map и return получить bind? 
6. Как связаны побочные эффекты, ссылочная прозрачность и чистота функций? Почему в Haskell функции по-умолчанию чистые?
7. Как сделать ранний возврат из функции в F# без использования исключений?

### Практика
1. Использовать [Result Computation Expression](https://fsharpforfunandprofit.com/posts/computation-expressions-intro/) для обработки ошибок калькулятора на F#. Программа не должна выбрасывать исключения.
2. Добавить тесты на операции с типами int, float, double, decimal). Допустимо использовать несколько билдеров, inline-функций, дженерики вида ’ или ^ и другие возможности F#. Предпочтение следует отдать решениям с минимальным дублированием кода.