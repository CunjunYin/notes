namespace Memento;

public class Program
{
    public static void Main(string[] args)
    {
        Originator originator = new Originator();
        originator.State = "Active";

        Caretaker caretaker= new Caretaker();
        caretaker.AddMemento("Active", originator.CreateMemento());

        originator.Print();
        originator.State = "Terminate";
        originator.Print();

        originator.SetMemento(caretaker.GetMemento("Active"));
        originator.Print();
    }
}