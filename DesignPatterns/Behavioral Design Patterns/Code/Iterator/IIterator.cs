namespace Iterator;

public interface IIterator
{
    object Current { get; }
    object Next();
    bool HasNext();
}
