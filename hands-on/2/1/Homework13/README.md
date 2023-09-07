# Домашняя работа №13 

## Память

### Теория
 1. [Андрей Акиньшин — Поговорим про память](https://www.youtube.com/watch?v=XGtieBVI1lk)
 2.  [Getting started with dotMemory](https://www.youtube.com/watch?v=6Tmcx6cTExg)
 3. [dotMemory Unit - .NET memory usage monitoring with unit tests](https://www.youtube.com/watch?v=SGwdb5FXuNk)
 4. *Факультатив:* [.NET GC Internals](https://www.youtube.com/playlist?list=PLpUkQYy-K8Y-wYcDgDXKhfs6OT8fFQtVm)

### Практика
Задание в парах 
1. Профилировать по времени выполнения (используя Benchmark .NET) и по памяти ([настройка Benchmark .NET](https://adamsitnik.com/the-new-Memory-Diagnoser/)): обычные, виртуальные, статические, generic-методы, dynamic, reflection. Что быстрее, на сколько? Приложить скриншоты измерений.
2. Заменить реализацию кеша. Вместо БД использовать оперативную память.
3. Попробовать с помощью Theory создать 10 миллионов строк с разными вычислениями (если не получится с Theory см. ниже). Запустить, профилировать в dotMemory Unit, посмотреть за потреблением памяти. Ставим Assert на потребление памяти в соответствие с количеством данных, которые вы рассчитаете самостоятельно на основе длины строк). **Если Theory или xUnit не совместимы с dotMemory Unit, то реализовать тесты как уж получится.**