namespace Iterator;

public class ConcreteIterator : IIterator
{
    public ConcreeteAggregate Aggregate;
    public object Current
    {
        get { return Aggregate[0]; }
    }

    private int Index = 0;

    public ConcreteIterator(ConcreeteAggregate aggregate)
    {
        Aggregate = aggregate;
    }

    public object Next()
    {
        Index++;
        if (HasNext())
        {
            return Aggregate[Index];
        }

        return null;
    }

    public bool HasNext()
    {
        return Index < Aggregate.Count;
    }
}