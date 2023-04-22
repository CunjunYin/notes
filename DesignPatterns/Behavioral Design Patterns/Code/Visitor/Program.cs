public interface IObject
{
    public void Accept(IVisitor visitor);
}

public class ConcreteObjectA : IObject
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteObjectA(this);
    }

    public string ConcreteObjectAMethod()
    {
        return "ConcreteObjectA";
    }
}

public class ConcreteObjectB : IObject
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteObjectB(this);
    }

    public string ConcreteObjectBMethod()
    {
        return "ConcreteObjectB";
    }
}

public interface IVisitor
{
    public void VisitConcreteObjectA(ConcreteObjectA obj);

    public void VisitConcreteObjectB(ConcreteObjectB obj);
}

public class ConcreteVisitorA : IVisitor
{
    public void VisitConcreteObjectA(ConcreteObjectA obj)
    {
        Console.WriteLine("VisitConcreteObjectA " + obj.ConcreteObjectAMethod());
    }

    public void VisitConcreteObjectB(ConcreteObjectB obj)
    {
        Console.WriteLine("VisitConcreteObjectB " + obj.ConcreteObjectBMethod());
    }
}

public class Client
{
    private IList<IObject> list;

    public Client()
    {
        list = new List<IObject>();
    }

    public void Attach(IObject obj)
    {
        list.Add(obj);
    }

    public void Detach(IObject obj)
    {
        list.Remove(obj);
    }

    public void Accept(IVisitor visitor)
    {
        foreach (IObject obj in list)
        {
            obj.Accept(visitor);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Client client = new Client();
        client.Attach(new ConcreteObjectA());
        client.Attach(new ConcreteObjectB());

        ConcreteVisitorA vistor = new ConcreteVisitorA();
        client.Accept(vistor);
    }
}