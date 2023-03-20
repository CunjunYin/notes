public interface ITarget
{
    public void Targetrequest();
}

public class ConcreteTarget : ITarget
{
    public void Targetrequest()
    {
        Console.WriteLine("Target method");
    }
}

public class Adaptee
{
    public void AdapteeRequest()
    {
        Console.WriteLine("Adaptee method");
    }
}

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Targetrequest()
    {
        _adaptee.AdapteeRequest();
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var adaptee = new Adaptee();
        var target = new Adapter(adaptee);
        target.Targetrequest();
    }
}