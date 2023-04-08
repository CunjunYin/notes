namespace Iterator;

public interface IAggregate<T>
{
    object this[T val] { get; set; }
    IIterator CreateIterator();
}