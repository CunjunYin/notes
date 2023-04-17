using System.Security.Cryptography;

namespace Command;

public abstract class ICommand
{
    public Receiver receiver;

    public ICommand(Receiver receiver)
    {
        this.receiver = receiver;
    }

    public abstract void Execute();
}

internal class ConcreteCommandOne : ICommand
{
    public ConcreteCommandOne(Receiver receiver) : base(receiver)
    {
    }

    public override void Execute()
    {
        this.receiver.ActionOne();
    }
}

internal class ConcreteCommandTwo : ICommand
{
    private Receiver _receiver;

    public ConcreteCommandTwo(Receiver receiver) : base(receiver)
    {
    }

    public override void Execute()
    {
        this.receiver.ActionTwo();
    }
}

public class Receiver
{
    public void ActionOne()
    {
        Console.WriteLine($"Receiver: Action One");
    }

    public void ActionTwo()
    {
        Console.WriteLine($"Receiver: Action Two");
    }
}

public class Invoker
{
    private IList<ICommand> command;

    public Invoker()
    {
        this.command = new List<ICommand>();
    }

    public void AddCommand(ICommand command)
    {
        this.command.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach(ICommand command in this.command)
        {
            command.Execute();
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Invoker invoker = new Invoker();
        Receiver receiver = new Receiver();
        invoker.AddCommand(new ConcreteCommandOne(receiver));
        invoker.AddCommand(new ConcreteCommandTwo(receiver));
        invoker.ExecuteCommands();
    }
}