namespace Iterator;
public class Program
{
    public static void Main(string[] args)
    {
        ConcreeteAggregate concreeteAggregate = new ConcreeteAggregate();
        concreeteAggregate[0] = "Hello";
        concreeteAggregate[1] = "World";

        IIterator iterator = new ConcreteIterator(concreeteAggregate);
        var item = iterator.Current;
        while (iterator.HasNext())
        {
            Console.WriteLine(item);
            item = iterator.Next();
        }
    }
}
