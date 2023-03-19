namespace Prototype;
public class Program
{
    public static void Main(string[] args)
    {
        Prototype prototype = new Prototype()
        {
            Name= "prototype",
            Date= DateTime.Now,

        };

        Console.WriteLine("========================================");
        Console.WriteLine("Shallow Clone");
        Console.WriteLine("========================================");
        Prototype cloned = prototype.ShallowClone();
        Console.WriteLine("prototype Name: {0}, cloned Name: {1}", prototype.Name, cloned.Name);
        Console.WriteLine("prototype Date: {0}, cloned Date: {1}", prototype.Date, cloned.Date);

        Console.WriteLine("\nAlter prototype date");
        Console.WriteLine("----------------------------------------");

        prototype.Name = "Modified";
        prototype.Date = DateTime.Now;
        Thread.Sleep(1000);
        Console.WriteLine("prototype {0}, cloned: {1}", prototype.Name, cloned.Name);
        Console.WriteLine("prototype {0}, cloned: {1}", prototype.Date, cloned.Date);

        Console.WriteLine("\n========================================");
        Console.WriteLine("Deep Clone");
        Console.WriteLine("========================================");

        cloned = prototype.DeepClone();
        Console.WriteLine("prototype Name: {0}, cloned Name: {1}", prototype.Name, cloned.Name);
        Console.WriteLine("prototype Date: {0}, cloned Date: {1}", prototype.Date, cloned.Date);

        Console.WriteLine("\nAlter prototype date");
        Console.WriteLine("----------------------------------------");
        prototype.Name = "Modified";
        prototype.Date = DateTime.Now;
        Thread.Sleep(1000);
        Console.WriteLine("prototype {0}, cloned: {1}", prototype.Name, cloned.Name);
        Console.WriteLine("prototype {0}, cloned: {1}\n", prototype.Date, cloned.Date);
    }
}
