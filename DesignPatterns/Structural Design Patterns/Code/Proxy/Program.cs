namespace Proxy;

public class Program
{
    public static void Main(string[] args)
    {
        Proxy proxy = new Proxy(new RealSubject());
        proxy.Request();
    }
}