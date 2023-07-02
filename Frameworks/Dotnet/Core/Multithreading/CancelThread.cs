using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading;

public class CancelThread
{
    public void Run()
    {
        // Create the token source.
        CancellationTokenSource cts = new CancellationTokenSource();

        // Pass the token to the cancelable operation.
        ThreadPool.QueueUserWorkItem(new WaitCallback(DoSomeWork), cts.Token);
        Thread.Sleep(2500);

        // Request cancellation.
        cts.Cancel();
        Debug.WriteLine("Cancellation set in token source...");
        Thread.Sleep(2500);
        // Cancellation should have happened, so call Dispose.
        cts.Dispose();
    }

    static void DoSomeWork(object? obj)
    {
        if (obj is null)
            return;

        CancellationToken token = (CancellationToken)obj;
        for (int i = 0; i < 100000; i++)
        {
            if (token.IsCancellationRequested)
            {
                Debug.WriteLine("In iteration {0}, cancellation has been requested...",  i + 1);
                break;
            }
            Thread.SpinWait(500000);
        }
    }
}
