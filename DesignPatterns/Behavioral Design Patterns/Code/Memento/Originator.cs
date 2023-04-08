namespace Memento;

public class Originator
{
    public string State { get; set; }

    public Originator(){}

    public Memento CreateMemento()
    {
        return new Memento(this.State);
    }

    public void SetMemento(Memento memento)
    {
        this.State = memento.State;
    }

    public void Print()
    {
        Console.WriteLine(this.State);
    }
}