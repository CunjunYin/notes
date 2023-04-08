namespace Iterator;

public class ConcreeteAggregate : IAggregate<int>
{
    private List<object> Items;
    public int Count
    {
        get { return Items.Count; }
    }

    public object this[int index]
    {
        get { return Items[index]; }
        set { Items.Insert(index, value); }
    }

    public ConcreeteAggregate()
    {
        Items = new List<object> { };
    }
    public IIterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }
}