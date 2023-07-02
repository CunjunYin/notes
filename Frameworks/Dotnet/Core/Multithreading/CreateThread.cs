using System.Diagnostics;

namespace Multithreading;

public class CreateThread
{
    public void Run()
    {
        //var simpleThread = new Thread(new ThreadStart(new SimpleThread().PrintMethod));
        //simpleThread.Start();
        //Console.WriteLine("Call after thread");
        //Console.WriteLine("Simple Thread task has completed; Join Main Thread");

        //Console.WriteLine();

        //var stateThread = new Thread(new ThreadStart(new ThreadWithState("ThreadWithState Mesage").PrintMethod));
        //stateThread.Start(); Console.WriteLine("Call after thread");
        //Console.WriteLine("State Thread has completed; Join Main Thread");

        //Console.WriteLine();

        //var callbackThread = new Thread(new ThreadStart(new ThreadWithCallback("ThreadWithState Mesage", ResultCallback).PrintMethod));
        //callbackThread.Start(); Console.WriteLine("Call after thread");
        //Console.WriteLine("Callback Thread has completed; Join Main Thread");

        //simpleThread.Join();
        //stateThread.Join();
        //callbackThread.Join();

        var thread = new PassDataThread();
        var passDataThread1 = new Thread(new ThreadStart(() => thread.Count(10)));
        passDataThread1.Start();

        var passDataThread2 = new Thread(thread.GenericCount);
        passDataThread2.Start(10);
    }

    public static void ResultCallback(int lineCount)
    {
        Console.WriteLine("Independent task printed {0} lines.", lineCount);
    }
}

public class SimpleThread
{
    public void PrintMethod()
    {
        Console.WriteLine("ServerClass.InstanceMethod is running on another thread.");

        // Pause for a moment to provide a delay to make threads more apparent.
        Thread.Sleep(3000);
        Console.WriteLine("The instance method called by the worker thread has ended.");
    }
}

public class ThreadWithState
{
    // State information used in the task.
    private string boilerplate;

    // The constructor obtains the state information.
    public ThreadWithState(string text)
    {
        boilerplate = text;
    }

    public void PrintMethod()
    {
        Thread.Sleep(5000);
        Console.WriteLine(boilerplate);
    }
}

public delegate void ExampleCallback(int lineCount);

public class ThreadWithCallback
{
    // State information used in the task.
    private string boilerplate;

    // Delegate used to execute the callback method when the task is complete.
    private ExampleCallback callback;

    // The constructor obtains the state information.
    public ThreadWithCallback(string text, ExampleCallback callback)
    {
        boilerplate = text;
        this.callback = callback;
    }

    public void PrintMethod()
    {
        Thread.Sleep(1000);
        Console.WriteLine(boilerplate);
        if (callback != null)
            callback(1);
    }
}

public class PassDataThread
{
    public void GenericCount(object count)
    {
        Count((int)count);
    }
    public void Count(int count)
    {
        Console.WriteLine("Foreground Thrread started");
        for (int i = 0; i < count; i++)
        {
            try
            {
                Debug.WriteLine($"Foreground count {i}");
                Thread.Sleep(1000);
            }
            catch (ThreadInterruptedException)
            {
                Debug.WriteLine("Thread Foreground Thrread Interrupted");
            }

        }
    }
}