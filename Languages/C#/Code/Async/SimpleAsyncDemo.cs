namespace Async;
public class SimpleAsyncDemo
{
    public SimpleAsyncDemo() { }
    public async Task taskAsync()
    {
        var msg = " I slept for ";
        var resultAsync = taskAsync(2000, msg);

        task(msg);
        await resultAsync;
    }

    public async Task taskRunAsync()
    {
        var msg = " I slept for ";
        var resultAsync = Task.Run(() => {
            Task.Delay(3000);
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} I am Task 1 and{msg}{3000}ms");
        });

        task(msg);
        await resultAsync;
    }

    private async Task<bool> taskAsync(int milliseconds, string msg)
    {
        await Task.Delay(milliseconds);
        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} I am Task 1 and{msg}{milliseconds}ms");
        return true;
    }

    private bool task(string msg)
    {
        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} I am Task 2");
        return true;
    }
}
