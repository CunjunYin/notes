using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading;

public class ThreadState
{
    public void Run()
    {
        Thread t1 = new Thread(ProcessTwo);
        Thread t2 = new Thread(PorcessOne);
        t2.Start();
        t1.Start();
        for (int i = 0; i < 10; i++)
        {

            Thread.Sleep(TimeSpan.FromMilliseconds(300));
            Console.WriteLine(t1.ThreadState.ToString());
        }

        Thread.Sleep(TimeSpan.FromSeconds(4));
        t1.Interrupt();
        t2.Join();
        Console.WriteLine(string.Format("t1 State：{0}", t1.ThreadState.ToString()));
        Console.WriteLine(string.Format("t2 State：{0}", t2.ThreadState.ToString()));
        Console.Read();
    }

    public static void PorcessOne()
    {
        Console.WriteLine("Thread PorcessOne started");
        Thread.Sleep(3000);
    }

    public static void ProcessTwo()
    {
        Console.WriteLine("Thread ProcessTwo started");
        for (int i = 0; i < 10; i++)
        {
            try
            {
                Thread.Sleep(10000);
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Thread ProcessTwo Interrupted");
            }

        }
    }
}
