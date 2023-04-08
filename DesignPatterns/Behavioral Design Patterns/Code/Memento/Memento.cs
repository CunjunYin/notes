namespace Memento;

public class Memento
{
    private string state;

    public string State
    { get { return state; } }

    public Memento(string state)
    {
        this.state = state;
    }
}