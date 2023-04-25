using System.Collections;

public interface IFlyweightObject
{
    public void FlyweightMethod();
}
public class Flyweight: IFlyweightObject
{
    public void FlyweightMethod()
    {
        Console.WriteLine("Flyweight Method");
    }
}

public class FlyweightFactory
{
    private Hashtable flyweights;

    public FlyweightFactory()
    {
        flyweights = new Hashtable
        {
            { "A", new Flyweight() }
        };
    }

    public IFlyweightObject GetFlyweight(string key)
    {
        object flyweight;

        if (flyweights.ContainsKey(key))
        {
            return (IFlyweightObject)flyweights[key];
        }
        return null;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        FlyweightFactory factory = new FlyweightFactory();
        IFlyweightObject flyweight = factory.GetFlyweight("A");
        flyweight.FlyweightMethod();
    }
}