namespace TemplateMethod;

public class ConcreteClass1 : AbstractClass
{
    public override void Operation1()
    {
        Console.WriteLine("ConcreteClass1: Operation1");
    }

    public override void Operation2()
    {
        Console.WriteLine("ConcreteClass1: Operation2");
    }
}

public class ConcreteClass2 : AbstractClass
{
    public override void Operation1()
    {
        Console.WriteLine("ConcreteClass2: Operation1");
    }

    public override void Operation2()
    {
        Console.WriteLine("ConcreteClass2: Operation2");
    }
}