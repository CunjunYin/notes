namespace Prototype;
public class Program
{
    public static void Main(string[] args)
    {
        Prototype prototype = new Prototype()
        {
            Name= "Test",
            Date= DateTime.Now,

        };

        Console.WriteLine("========================================");
        Console.WriteLine("Shallow Clone");
        Console.WriteLine("========================================");
        Prototype cloned = prototype.ShallowCopy();
        Console.WriteLine("prototype Name: {0}, cloned Name: {1}", prototype.Name, cloned.Name);
        Console.WriteLine("prototype Date: {0}, cloned Date: {1}", prototype.Date, cloned.Date);

        Console.WriteLine("\n========================================");
        Console.WriteLine("Alter prototype date");
        Console.WriteLine("========================================");

        prototype.Date = DateTime.Now;
        Thread.Sleep(1000);
        Console.WriteLine("prototype {0}, cloned: {1}", prototype.Name, cloned.Name);
        Console.WriteLine("prototype {0}, cloned: {1}", prototype.Date, cloned.Date);

        Console.WriteLine("========================================");
        Console.WriteLine("Deep Clone");
        Console.WriteLine("========================================");

        cloned = prototype.DeepCopy();
        Console.WriteLine("prototype Name: {0}, cloned Name: {1}", prototype.Name, cloned.Name);
        Console.WriteLine("prototype Date: {0}, cloned Date: {1}", prototype.Date, cloned.Date);

        Console.WriteLine("\n========================================");
        Console.WriteLine("Alter prototype date");
        Console.WriteLine("========================================");
        prototype.Date = DateTime.Now;
        Thread.Sleep(1000);
        Console.WriteLine("prototype {0}, cloned: {1}", prototype.Name, cloned.Name);
        Console.WriteLine("prototype {0}, cloned: {1}", prototype.Date, cloned.Date);
    }
}
