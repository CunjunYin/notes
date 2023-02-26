namespace Async;
public class AsyncDemo
{
    public AsyncDemo() { }
    public async Task<bool> runAsync()
    {
        var msg = " I slept for ";
        var task = Task.Run(() => Task1(200, msg));
        Task2(msg);
        return await task;
    }

    public async Task<bool> runWithCancellationTokenAsync()
    {
        var msg = " I slept for ";
        var task = Task.Run(() => Task1(200, msg));
        Task2(msg);
        return await task;
    }

    private bool Task1(int milliseconds, string msg)
    {
        Thread.Sleep(milliseconds);
        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} I am Task 1 and{msg}{milliseconds}ms");
        return true;
    }

    private bool Task2(string msg)
    {
        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} I am Task 2");
        return true;
    }
}
