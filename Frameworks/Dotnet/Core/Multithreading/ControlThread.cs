namespace Multithreading;

public class ControlThread
{
    public void Run()
    {
        var sleepingThread = new Thread(new ThreadStart(SleepThread.SleepIndefinitely));
        sleepingThread.Name = "Sleeping";
        sleepingThread.Start();
        Thread.Sleep(2000);
        sleepingThread.Interrupt();

        Thread.Sleep(1000);
    }
}

public class SleepThread
{
    public static void SleepIndefinitely()
    {
        Console.WriteLine("Thread '{0}' about to sleep indefinitely.",
                          Thread.CurrentThread.Name);
        try
        {
            Thread.Sleep(Timeout.Infinite);
        }
        catch (ThreadInterruptedException)
        {
            Console.WriteLine("Thread '{0}' awoken.",
                              Thread.CurrentThread.Name);
        }
        catch (ThreadAbortException)
        {
            Console.WriteLine("Thread '{0}' aborted.",
                              Thread.CurrentThread.Name);
        }
        finally
        {
            Console.WriteLine("Thread '{0}' executing finally block.",
                              Thread.CurrentThread.Name);
        }
        Console.WriteLine("Thread '{0} finishing normal execution.",
                          Thread.CurrentThread.Name);
        Console.WriteLine();
    }
}