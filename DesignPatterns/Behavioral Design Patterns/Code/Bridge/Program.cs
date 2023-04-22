public interface IAbstraction
{
    public string Operation();
}

public class Abstraction : IAbstraction
{
    protected IImplementation Implementation;

    public Abstraction(IImplementation implementation)
    {
        this.Implementation = implementation;
    }

    public virtual string Operation()
    {
        return "Abstraction -> " + Implementation.Operation();
    }
}

public interface IImplementation
{
    string Operation();
}

public class ConcreteImplementationA : IImplementation
{
    public string Operation()
    {
        return "Result from ConcreteImplementationA";
    }
}

public class ConcreteImplementationB : IImplementation
{
    public string Operation()
    {
        return "Result from ConcreteImplementationB";
    }
}

public class Client
{
    public string Implementation;

    public Client(string implementation)
    {
        Implementation = implementation;
    }

    public void RunOperation()
    {
        IAbstraction abstraction;
        switch (Implementation)
        {
            case "A":
                abstraction = new Abstraction(new ConcreteImplementationA());
                Console.Write(abstraction.Operation());
                break;

            case "B":
                abstraction = new Abstraction(new ConcreteImplementationB());
                Console.Write(abstraction.Operation());
                break;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 1)
        {
            new Client(args[0]).RunOperation();
        }
    }
}