namespace Observer.DelegateSubject;

public class DelegateObserverA
{
    public void Update(object sender, EventArgs e)
    {
        Console.WriteLine($"Observer: DelegateObserverA, Subject state {sender}");
    }
}

public class DelegateObserverB
{
    public void Method(object sender, EventArgs e)
    {
        Console.WriteLine($"Observer: DelegateObserverB, Subject state {sender}");
    }
}

public class DelegateSubject
{
    public string State;

    public event EventHandler events;

    public void Notify()
    {
        events?.Invoke(State, EventArgs.Empty);
    }
}