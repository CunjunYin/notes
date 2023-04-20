namespace Mediator;
public interface IMediator
{
    public void Transfer(object sender, object msg);
}

public class Mediator : IMediator
{
    public Object ConcreteObjectA { get; set; }
    public Object ConcreteObjectB { get; set; }

    public void Transfer(object sender, object msg)
    {
        if (sender.GetType() == typeof(ConcreteObjectA))
        {
            ConcreteObjectB.Notify(msg);
        }

        if (sender.GetType() == typeof(ConcreteObjectB))
        {
            ConcreteObjectA.Notify(msg);
        }
    }
}

public abstract class Object
{
    protected IMediator mediator;

    public Object(IMediator? mediator)
    {
        this.mediator = mediator!;
    }

    public void SetMediator(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public void Send(object msg)
    {
        this.mediator.Transfer(this, msg);
    }

    public abstract void Notify(object msg);
}

public class ConcreteObjectA : Object
{
    public ConcreteObjectA(IMediator? mediator) : base(mediator)
    {
    }

    public override void Notify(object msg)
    {
        Console.WriteLine($"ConcreteObjectA received mesage: {msg}");
    }
}

public class ConcreteObjectB : Object
{
    public ConcreteObjectB(IMediator? mediator) : base(mediator)
    {
    }

    public override void Notify(object msg)
    {
        Console.WriteLine($"ConcreteObjectB received mesage: {msg}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Mediator mediator = new Mediator();
        Object concreteObjectA = new ConcreteObjectA(mediator);
        Object concreteObjectB = new ConcreteObjectB(mediator);
        mediator.ConcreteObjectA = concreteObjectA;
        mediator.ConcreteObjectB = concreteObjectB;

        concreteObjectA.Send("How Are you");
        concreteObjectB.Send("Very Good");
    }
}