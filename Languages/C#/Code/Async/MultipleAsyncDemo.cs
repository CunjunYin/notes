using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async;

public class MultipleAsyncDemo
{
    public MultipleAsyncDemo() { }

    public async Task tasksAsync()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var task1 = task1Async();
        var task2 = task2Async();
        var task3 = task3Async();

        Console.WriteLine("All tasks started");

        await task1;
        await task2;
        await task3;

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine($"Exeuction time {elapsedMs}ms");
    }

    public async Task tasksWhenAllAsync()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var task1 = task1Async();
        var task2 = task2Async();
        var task3 = task3Async();

        Console.WriteLine("All tasks started");

        await Task.WhenAll(task1, task2, task3);

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine($"Exeuction time {elapsedMs}ms");
    }

    public async Task tasksWhenAnyAsync()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var task1 = task1Async();
        var task2 = task2Async();
        var task3 = task3Async();

        Console.WriteLine("All tasks started");

        var tasks = new List<Task> { task1, task2, task3 };
        while (tasks.Count > 0)
        {
            Task finishedTask = await Task.WhenAny(tasks);
            await finishedTask;
            tasks.Remove(finishedTask);
        }

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine($"Total Exeuction time {elapsedMs}ms");
    }

    public async Task<bool> task1Async()
    {
        await Task.Delay(3000);
        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} task 1 complete");
        return true;
    }

    public async Task<bool> task2Async()
    {
        await Task.Delay(5000);
        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} task 2 complete");
        return true;
    }

    public async Task<bool> task3Async()
    {
        await Task.Delay(1000);
        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} task 3 complete");
        return true;
    }
}
