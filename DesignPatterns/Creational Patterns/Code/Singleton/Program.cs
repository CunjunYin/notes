
namespace Singleton;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("====================");
        Console.WriteLine("New Instance");
        Console.WriteLine("====================");
        newInstance();

        Console.WriteLine("====================");
        Console.WriteLine("Signleton");
        Console.WriteLine("====================");
        signleton();
    }

    private static void signleton()
    {
        SingletonDemo instance1 = SingletonDemo.GetInstance();
        SingletonDemo instance2 = SingletonDemo.GetInstance();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(instance1.GetNextData());
            Console.WriteLine(instance2.GetNextData());
        }
    }

    private static void newInstance()
    {
        SingletonDemo instance1 = new SingletonDemo();
        SingletonDemo instance2 = new SingletonDemo();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(instance1.GetNextData());
            Console.WriteLine(instance2.GetNextData());
        }
    }
}