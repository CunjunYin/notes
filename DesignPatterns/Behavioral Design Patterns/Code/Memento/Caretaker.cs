namespace Memento;

public class Caretaker
{
    private IDictionary<string, Memento> Mementos;

    public Caretaker()
    {
        this.Mementos = new Dictionary<string, Memento>();
    }

    public void AddMemento(string key, Memento memento)
    {
        Mementos.Add(key, memento);
    }

    public Memento GetMemento(string key)
    {
        Memento memento;

        if (this.Mementos.TryGetValue(key, out memento))
        {
            return memento;
        }
        return null;
    }
}