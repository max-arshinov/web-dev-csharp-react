namespace Tests.CSharp.Homework11;

public static class UserMessagerForTest
{
    public static string WaitingTimeIsLess(long minExpectedTime, long executionTime)
    {
        return $@"Время подсчета меньше ожидаемого.
           Мин время: {minExpectedTime}, актуальное время: {executionTime}";
    }

    public static string WaitingTimeIsMore(long maxExpectedTime, long executionTime)
    {
        return $@"Время подсчета больше ожидаемого.
           Макс время: {maxExpectedTime}, актуальное время: {executionTime});";
    }
}