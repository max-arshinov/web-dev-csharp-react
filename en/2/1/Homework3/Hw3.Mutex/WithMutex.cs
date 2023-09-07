using System.IO.MemoryMappedFiles;

namespace Hw3.Mutex;

public class WithMutex: IDisposable
{
    private static readonly string MutexName = "Global\\MyMutex__!";

    private bool _disposed;
    
    private readonly System.Threading.Mutex _mutex;

    private int _index;

    public const int Delay = 3000;
    
    public WithMutex()
    {
        _mutex = new System.Threading.Mutex(false, MutexName);
        _mutex.WaitOne(Delay + 100);
    }

    public int Increment()
    {
        _index = 100500;
        Thread.Sleep(Delay);
        return _index;
    }
    
    // https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
    public void Dispose()
    {
        // Dispose of unmanaged resources.
        Dispose(true);
        // Suppress finalization.
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // no managed resources
            // this "if" statement is intentionally empty 
            // for educational purposes
            // You don't need it in the production code
        }

        _mutex.ReleaseMutex();
        _disposed = true;
    }
    
    ~WithMutex() => Dispose(false);
}