internal abstract class AbstractHandler
{
    protected AbstractHandler successor;

    public AbstractHandler SetSuccessor(AbstractHandler handler)
    {
        this.successor = handler;
        return this.successor;
    }

    public abstract void Handle(object request);
}

internal class ConcreteHandlerA : AbstractHandler
{
    public override void Handle(object request)
    {
        if (string.IsNullOrEmpty((request as string)))
        {
            Console.WriteLine("Empty request");
        }
        else if (this.successor != null)
        {
            this.successor.Handle(request);
        }
    }
}

internal class ConcreteHandlerB : AbstractHandler
{
    public override void Handle(object request)
    {
        if ((request as string).Equals("Active"))
        {
            Console.WriteLine("Request state equals Active");
        }
        else if (this.successor != null)
        {
            this.successor.Handle(request);
        }
    }
}

internal class ConcreteHandlerC : AbstractHandler
{
    public override void Handle(object request)
    {
        if ((request as string).Equals("Pause"))
        {
            Console.WriteLine("Request state equals Pause");
        }
        else if (this.successor != null)
        {
            this.successor.Handle(request);
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // The other part of the client code constructs the actual chain.
        var chain = new ConcreteHandlerA();
        chain.SetSuccessor(new ConcreteHandlerB()).SetSuccessor(new ConcreteHandlerC());

        var requests = new List<string> { "", "Pause", "BadRequest", "Active" };

        foreach (var request in requests)
        {
            chain.Handle(request);
        }
    }
}