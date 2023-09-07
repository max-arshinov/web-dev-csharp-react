using System.Collections.Concurrent;

namespace Tests.CSharp.Homework3;

public static class Concurrency
{
    private static int _index;

    private static readonly ManualResetEvent Event = new(false);

    private static readonly SemaphoreSlim SemaphoreSlim = new(1, 1);

    // https://habr.com/ru/post/198104/
    private static readonly ConcurrentDictionary<string, int> _dict = new();

    private static readonly object Locker = new();

    public static int Index => _index;

    public static int IncrementWithLock(int threadCount, int iterations)
    {
        return DoIncrement(threadCount, iterations, () =>
        {
            lock (Locker)
            {
                _index++;
            }
        });
    }

    public static int IncrementWithInterlocked(int threadCount, int iterations)
    {
        return DoIncrement(threadCount, iterations, () => { Interlocked.Increment(ref _index); });
    }

    public static int Increment(int threadCount, int iterations)
    {
        return DoIncrement(threadCount, iterations, () => _index++);
    }

    public static int IncrementWithConcurrentDictionary(int threadCount, int iterations)
    {
        return _index = DoIncrement(threadCount, iterations,
            () => _dict.AddOrUpdate("index",
                static _ => 0,
                static (_, v) => v + 1));
    }

    private static int DoIncrement(int threadCount, int iterations, Action increment)
    {
        _index = 0;
        var threads = new List<Thread>();
        for (var i = 0; i < threadCount; i++)
        {
            var t = new Thread(() =>
            {
                Event.WaitOne();
                for (var j = 0; j < iterations; j++) increment();
            }) { IsBackground = true };
            threads.Add(t);
            t.Start();
        }

        Event.Set();
        threads.ForEach(t => t.Join());
        return iterations * threadCount;
    }

    /// <summary>
    ///     https://www.rocksolidknowledge.com/articles/locking-and-asyncawait
    /// </summary>
    /// <returns></returns>
    public static async Task<int> IncrementAsync(int taskCount, int iterations)
    {
        _index = 0;
        var tasks = new List<Task>();
        for (var i = 0; i < taskCount; i++)
        {
            var t = Task.Run(async () =>
            {
                Event.WaitOne();
                for (var j = 0; j < iterations; j++)
                {
                    await SemaphoreSlim.WaitAsync();
                    Thread.MemoryBarrier();
                    _index++;
                    Thread.MemoryBarrier();
                    SemaphoreSlim.Release();
                }
            });
            tasks.Add(t);
        }

        Event.Set();
        await Task.WhenAll(tasks);
        return iterations * taskCount;
    }
}