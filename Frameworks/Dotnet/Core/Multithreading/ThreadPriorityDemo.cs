using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading;

public class ThreadPriorityDemo
{
    public void Run()
    {
        Console.WriteLine("Master thread：" + Thread.CurrentThread.Priority);

        //Multiple Thread
        Console.WriteLine("Multiple Thread");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Threads();
        stopwatch.Stop();
        Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

        Thread.Sleep(TimeSpan.FromSeconds(2));

        //Single Thread
        Console.WriteLine("Single Thread");
        Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
        stopwatch.Start();
        Threads();
        stopwatch.Stop();
        Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
    }

    static void Threads()
    {
        var demo = new ThreadRunDemo();
        Thread thread1 = new Thread(demo.CountNumber);
        thread1.Name = "ThreadOne";
        Thread thread2 = new Thread(demo.CountNumber);
        thread2.Name = "ThreadTwo";
        thread2.Priority = ThreadPriority.BelowNormal;
        Thread thread3 = new Thread(demo.CountNumber);
        thread3.Name = "ThreadThree";


        thread1.Priority = ThreadPriority.Highest;
        thread2.Priority = ThreadPriority.AboveNormal;
        thread3.Priority = ThreadPriority.Lowest;

        thread1.Start();
        thread2.Start();
        thread3.Start();

        Thread.Sleep(2000);
        demo.Stop();
    }
}

public class ThreadRunDemo
{
    private bool isStopped = false;
    public void Stop()
    {
        isStopped = true;
    }

    public void CountNumber()
    {
        long cnt = 0;
        while (!isStopped)
        {
            cnt++;
        }
        Console.WriteLine(
            string.Format(
                "Name {0}, Priority {1} ，Number: {2}",
                Thread.CurrentThread.Name,
                Thread.CurrentThread.Priority.ToString(),
                cnt.ToString("N0")
            )
        );

    }
}