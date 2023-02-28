# Async
Asynchronous programming can improve a programs's performance, by perform multiple tasks simultaneously. So asynchronous code will not block the application's main thread. While asynchronous programming can improve program performance, but asynchronous programming can be complex, making them difficult to write, debug, and maintain.

## Async/Await
In C# Asynchronous programming is typically done using the `async` and `await` keywords. The async keyword is used to define a method that can be executed asynchronously, and the await keyword is used to wait for the result of an asynchronous operation.

### Declear async method
```c#
public class SimpleAsyncDemo
{
    public SimpleAsyncDemo() { }

    public async Task taskAsync()
    {
        var msg = " I slept for ";
        var resultAsync = taskAsync(2000, msg);

        task();
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

    private bool task()
    {
        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} I am Task 2");
        return true;
    }
}
```

> The difference between `await Task.Run` and `await` is that `Task.Run` is used to run a method asynchronously on a thread from the thread pool. Generally in CPU-bound situation use Task.Run and for IO bound await keyword for async method.

#### Output
```js
2023-02-26 21:10:38.198 I am Task 2
2023-02-26 21:10:38.402 I am Task 1 and I slept for 200ms
```

### The use of `async` flag
When a methods marked with a `async` flag, it indicates that the `await` expression may be used in this method and this method is asynchronous. When the method is encounters an `await expression`, it will suspended execution code after await expression until the asynchronous code is completed. While the method is suspended, but the method is free to execute other async code before await expression occured.

## Stop Asynchronous code by `Cancellation Token`

##
The GetAwaiter() method is a part of the async programming model in C# that enables developers to write asynchronous code more easily. However, in certain situations, using GetAwaiter() can cause a deadlock.

A deadlock can occur when a method is blocked, waiting for an asynchronous operation to complete, but the thread that was used to initiate the asynchronous operation is blocked, waiting for the method to complete. This situation can arise when the GetAwaiter() method is called from a non-UI thread in a Windows Forms or WPF application, and the code that follows it attempts to access the UI thread.

In this scenario, the GetAwaiter() method captures the current synchronization context, which is typically the UI thread in a Windows Forms or WPF application. When the asynchronous operation completes, the code that follows the GetAwaiter() method is executed on the captured synchronization context. However, if the code that follows attempts to access the UI thread, it will be blocked, waiting for the UI thread to become available. Meanwhile, the UI thread is blocked, waiting for the method to complete, resulting in a deadlock.

To avoid this deadlock, it is recommended to use the ConfigureAwait(false) method when calling GetAwaiter(). This tells the async operation to not resume on the captured synchronization context, but instead, resume on any available thread from the thread pool. This can prevent the deadlock from occurring, as the UI thread will not be blocked by the asynchronous operation. However, it is important to note that using ConfigureAwait(false) can also have implications for the behavior of your code, so it should be used with caution and only in appropriate situations.
