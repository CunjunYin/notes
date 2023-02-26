namespace Async;
class Program
{
    static void Main(string[] args)
    {
        AsyncDemo demo = new AsyncDemo();
        demo.runAsync().Wait();
    }
}