using Observer.DelegateSubject;

namespace Observer;

public class Program
{
    public static void Main(string[] args)
    {
        var subject = new Subject.Subject();
        var observerA = new Subject.ConcreteObserverA();
        var observerB = new Subject.ConcreteObserverB();
        subject.Attach(observerA);
        subject.Attach(observerB);
        subject.State = "Active";
        subject.Notify();

        Console.WriteLine();

        var delegateSubject = new DelegateSubject.DelegateSubject();
        var delegateObserverA = new DelegateSubject.DelegateObserverA();
        var delegateObserverb = new DelegateSubject.DelegateObserverB();
        delegateSubject.events += delegateObserverA.Update;
        delegateSubject.events += delegateObserverb.Method;
        delegateSubject.State = "Active";
        delegateSubject.Notify();
    }
}