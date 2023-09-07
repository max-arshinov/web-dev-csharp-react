using System.Diagnostics;
using System.Runtime.InteropServices;
using Hw3.Mutex;
using Tests.RunLogic.Attributes;
using Xunit.Abstractions;

namespace Tests.CSharp.Homework3;

public class ConcurrencyTests
{
    private readonly ITestOutputHelper _toh;

    public ConcurrencyTests(ITestOutputHelper toh)
    {
        _toh = toh;
    }

    [Homework(Homeworks.HomeWork3)]
    public void SingleThread_NoRaces()
    {
        var expected = Concurrency.Increment(1, 1000);
        Assert.Equal(expected, Concurrency.Index);
    }

    [Homework(Homeworks.HomeWork3)]
    public void FiveThreads_100Iterations_RaceIsHardToReproduce()
    {
        var expected = Concurrency.Increment(5, 1000);
        Assert.Equal(expected, Concurrency.Index);
    }

    [Homework(Homeworks.HomeWork3)]
    public void EightThreads_100KIterations_RaceIsReproduced()
    {
        var expected = Concurrency.Increment(8, 100_000);
        Assert.NotEqual(expected, Concurrency.Index);
        _toh.WriteLine($"Expected: {expected}; Actual: {Concurrency.Index}");
    }

    [Homework(Homeworks.HomeWork3)]
    public void EightThreads_100KIterations_WithLock_NoRaces()
    {
        var expected = Concurrency.IncrementWithLock(8, 100_000);
        Assert.Equal(expected, Concurrency.Index);
        _toh.WriteLine($"Expected: {expected}; Actual: {Concurrency.Index}");
    }

    [Homework(Homeworks.HomeWork3)]
    public void EightThreads_100KIterations_LockIsSyntaxSugarForMonitor_NoRaces()
    {
        var expected = Concurrency.IncrementWithLock(8, 100_000);
        Assert.Equal(expected, Concurrency.Index);
        _toh.WriteLine($"Expected: {expected}; Actual: {Concurrency.Index}");
    }

    [Homework(Homeworks.HomeWork3)]
    public void EightThreads_100KIterations_WithInterlocked_NoRaces()
    {
        var expected = Concurrency.IncrementWithInterlocked(8, 100_000);
        Assert.Equal(expected, Concurrency.Index);
        _toh.WriteLine($"Expected: {expected}; Actual: {Concurrency.Index}");
    }

    [Homework(Homeworks.HomeWork3)]
    public void EightThreads_100KIterations_InterlockedIsFasterThanLock_Or_IsIt()
    {
        var isM1Mac = OperatingSystem.IsMacOS() &&
                      RuntimeInformation.ProcessArchitecture == Architecture.Arm64;

        var elapsedWithLock = StopWatcher.Stopwatch(EightThreads_100KIterations_WithLock_NoRaces);
        var elapsedWithInterlocked = StopWatcher.Stopwatch(EightThreads_100KIterations_WithInterlocked_NoRaces);

        _toh.WriteLine($"Lock: {elapsedWithLock}; Interlocked: {elapsedWithInterlocked}");

        // see: https://godbolt.org/z/1TzWMz4aj
        if (isM1Mac)
            Assert.True(elapsedWithLock < elapsedWithInterlocked);
        else
            Assert.True(elapsedWithLock > elapsedWithInterlocked);
    }

    public void Semaphore()
    {
        // TODO: homework+
    }

    [Homework(Homeworks.HomeWork3)]
    public async Task SemaphoreSlimWithTasks()
    {
        var expected = await Concurrency.IncrementAsync(8, 100_000);
        Assert.Equal(expected, Concurrency.Index);
    }

    public void NamedSemaphore_InterprocessCommunication()
    {
        // TODO: homework+
        // https://learn.microsoft.com/en-us/dotnet/standard/threading/semaphore-and-semaphoreslim#named-semaphores
        // see mutex as example
    }

    [Homework(Homeworks.HomeWork3)]
    public void ConcurrentDictionary_100KIterations_WithInterlocked_NoRaces()
    {
        var expected = Concurrency.IncrementWithConcurrentDictionary(8, 100_000);
        Assert.Equal(expected, Concurrency.Index);
    }

    [Homework(Homeworks.HomeWork3)]
    public async Task Mutex()
    {
        var p1 = new Process
        {
            StartInfo = GetProcessStartInfo()
        };
        var p2 = new Process
        {
            StartInfo = GetProcessStartInfo()
        };

        var sw = new Stopwatch();
        sw.Start();
        p1.Start();
        p2.Start();
        await p1.WaitForExitAsync();
        await p2.WaitForExitAsync();
        p1.WaitForExit();
        var val = await p1.StandardOutput.ReadToEndAsync();
        _toh.WriteLine(val);

        p2.WaitForExit();
        val = await p2.StandardOutput.ReadToEndAsync();
        sw.Stop();
        _toh.WriteLine(val);

        Assert.True(sw.Elapsed.TotalMilliseconds >= WithMutex.Delay * 2);
    }

    private static ProcessStartInfo GetProcessStartInfo()
    {
        return new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = "run --project ../../../../Hw3.Mutex/Hw3.Mutex.csproj",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };
    }
}