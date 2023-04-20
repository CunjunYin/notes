namespace Strategy;

public class Program
{
    public static void Main(string[] args)
    {
        var context = new Context();
        Console.WriteLine("Client: Strategy is set to normal sorting.");
        context.SetStrategy(new ConcreteStrategyA());
        context.ExecuteStrategy();

        Console.WriteLine();

        Console.WriteLine("Client: Strategy is set to reverse sorting.");
        context.SetStrategy(new ConcreteStrategyB());
        context.ExecuteStrategy();
    }
}