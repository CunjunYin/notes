namespace TemplateMethod;

public class Program
{
    public static void Main(string[] args)
    {
        AbstractClass c;
        c = new ConcreteClass1();
        c.TemplateMethod();

        c = new ConcreteClass2();
        c.TemplateMethod();
    }
}