namespace Async;
class Program
{
    static void Main(string[] args)
    {
        SimpleAsyncDemo demo = new SimpleAsyncDemo();
        demo.taskRunAsync().Wait();
    }
}