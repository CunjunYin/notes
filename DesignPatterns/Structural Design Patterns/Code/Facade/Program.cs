public class Facade
{
    public SubsystemA subsystemA {get; set;}
    public SubsystemB subsystemB {get; set;}

    public Facade(SubsystemA subsystemA, SubsystemB subsystemB)
    {
        this.subsystemA = subsystemA;
        this.subsystemB = subsystemB;
    }

    public string OperationOne()
    {
        var result = "";
        result += subsystemA.SubsystemAMethod();
        result += subsystemB.SubsystemBMethod();
        return result;
    }

    public string OperationTwo()
    {
        var result = "";
        result += subsystemB.SubsystemBMethod();
        result += subsystemA.SubsystemAMethod();
        return result;
    }
}

public class SubsystemA
{
    public string SubsystemAMethod()
    {
        return "Subsystem A: method\n";
    }
}

public class SubsystemB
{
    public string SubsystemBMethod()
    {
        return "Subsystem B: method\n";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SubsystemA subsystemA = new SubsystemA();
        SubsystemB subsystemB = new SubsystemB();
        Facade facade = new Facade(subsystemA, subsystemB);
        Console.WriteLine(facade.OperationOne());
        Console.WriteLine("====================");
        Console.WriteLine(facade.OperationTwo());
    }
}