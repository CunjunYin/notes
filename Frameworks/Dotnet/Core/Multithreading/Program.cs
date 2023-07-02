namespace Multithreading;

public class Program
{
    public static void Main()
    {
        //var createThread = new CreateThread();
        //createThread.Run();

        //var controlThread = new ControlThread();
        //controlThread.Run();

        //var threadState = new ThreadState();
        //threadState.Run();

        //var threadPriorityDemo = new ThreadPriorityDemo();
        //threadPriorityDemo.Run();

        //var groundThrerad = new GroundThread();
        //groundThrerad.Run();

        //var lockThread = new LockThread();
        //lockThread.Run();

        var cancelThread = new CancelThread();
        cancelThread.Run();
    }
}