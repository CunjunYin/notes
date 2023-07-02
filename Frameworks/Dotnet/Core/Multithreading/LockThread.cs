using System.Diagnostics;

namespace Multithreading;

public class LockThread
{
    public void Run()
    {
        //var counterLock = new CounterLock();
        //var t1 = new Thread(() => Count(counterLock));
        //var t2 = new Thread(() => Count(counterLock));

        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();

        //t1.Start();
        //t2.Start();

        //t1.Join();
        //t2.Join();

        //stopwatch.Stop();
        //Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

        //var counter = new Counter();
        //var t3 = new Thread(() => Count(counter));
        //var t4 = new Thread(() => Count(counter));

        //stopwatch.Restart();
        //stopwatch.Start();

        //t3.Start();
        //t4.Start();

        //t3.Join();
        //t4.Join();

        //stopwatch.Stop();
        //Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

        new MonitorLock().Run();
    }

    static void Count(CounterLock cnt)
    {
        for (int i = 0; i < 100; i++)
        {
            cnt.Incerement();
            cnt.Dncerement();
        }
    }

    static void Count(Counter cnt)
    {
        for (int i = 0; i < 100; i++)
        {
            cnt.Incerement();
            cnt.Dncerement();
        }
    }
}

public class Counter
{
    public int Count { get; private set; }
    public void Dncerement()
    {
        Thread.Sleep(10);
        Count--;
    }

    public void Incerement()
    {
        Thread.Sleep(10);
        Count++;
    }
}

public class CounterLock
{
    private readonly object objSync = new object();
    public int Count { get; private set; }
    public void Dncerement()
    {
        lock (objSync)
        {
            Thread.Sleep(10);
            Count--;
        }
    }

    public void Incerement()
    {
        lock (objSync)
        {
            Thread.Sleep(10);
            Count++;
        }
    }
}

public class MonitorLock
{
    public void Run()
    {
        var lock1 = new object();
        var lock2 = new object();


        Thread t = new Thread(() => DeadLock(lock1, lock2));

        t.Start();
        lock (lock2)
        {
            Thread.Sleep(2000);

            if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(5)))

            {
                Console.WriteLine("Intime");

            }
            else

            {
                Console.WriteLine("Overtime");

            }
        }

        new Thread(() => DeadLock(lock1, lock2)).Start();
        Console.WriteLine("-----------------------------");

        lock (lock2)
        {

            Thread.Sleep(1000);
            Console.WriteLine(string.Format("Deadlock"));

            lock (lock1)
            {
                Console.WriteLine("Success");

            }
        }
    }

    static void DeadLock(object objLock1, object objLock2)
    {
        lock (objLock1)
        {
            Thread.Sleep(2000);
            lock (objLock2)
            {
                Console.WriteLine("Dead Lock");
            }
        }
    }
}