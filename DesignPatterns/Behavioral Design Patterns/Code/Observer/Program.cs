namespace Observer;

public interface IObserver
{
    void Update(ISubject subject);
}

public interface ISubject
{
    string State { get; set; }

    void Attach(IObserver observer);

    void Detach(IObserver observer);

    void Notify();
}

public class Subject : ISubject
{
    public string State { get; set; }
    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        this._observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this._observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
}

public class ConcreteObserverA : IObserver
{
    public void Update(ISubject subject)
    {
        Console.WriteLine($"Observer: ConcreteObserverA, Subject state {subject.State}");
    }
}

public class ConcreteObserverB : IObserver
{
    public void Update(ISubject subject)
    {
        Console.WriteLine($"Observer: ConcreteObserverB, Subject state {subject.State}");
    }
}

public class Program
{
    private static void Main(string[] args)
    {
        var subject = new Subject();
        var observerA = new ConcreteObserverA();
        subject.Attach(observerA);

        var observerB = new ConcreteObserverB();
        subject.Attach(observerB);

        subject.State = "Active";
        subject.Notify();
    }
}