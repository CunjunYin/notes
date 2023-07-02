using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Multithreading;

public class GroundThread
{
    public void Run()
    {
        var background = new BackgroundThrread();
        var foreground = new ForegroundThrread();
        Thread threadBackground = new Thread(background.Count);
        Thread threadForeground = new Thread(foreground.Count);

        threadBackground.IsBackground= true;
        threadBackground.Name = "Background Thread";
        threadForeground.IsBackground = false;
        threadForeground.Name = "Foreground Thread";

        threadBackground.Start();
        threadForeground.Start();

        //threadForeground.Join();
        //threadBackground.Join();
    }
}

// Background threads are identical to foreground threads with one exception:
// a background thread does not keep the managed execution environment running.
public class BackgroundThrread
{
    public void Count()
    {
        Console.WriteLine("Background Thrread started");
        for (int i = 0; i < 5; i++) // for (int i = 0; i < 10; i++) 
        {
            try
            {
                Debug.WriteLine($"Background count {i}");
                Thread.Sleep(1000);
            }
            catch (ThreadInterruptedException)
            {
                Debug.WriteLine("Background Thrread Interrupted");
            }

        }
    }
}

// Foreground threads have been stopped in a managed process,
// the system stops all background threads and shuts down.
public class ForegroundThrread
{
    public void Count()
    {
        Console.WriteLine("Foreground Thrread started");
        for (int i = 0; i < 10; i++) // for (int i = 0; i < 5; i++)
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
