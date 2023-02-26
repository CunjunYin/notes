using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameAssembly.Access;
public class AccessDemo
{
    private void Demo() { }

    public void PublicDemo()
    {
        Console.WriteLine("Public Demo");
    }

    private void PrivateDemo()
    {
        Console.WriteLine("Private Demo");
    }

    protected void ProtectedDemo()
    {
        Console.WriteLine("Protected Demo");
    }

    internal void InternalDemo()
    {
        Console.WriteLine("Internal Demo");
    }

    protected internal void ProtectedInternalDemo()
    {
        Console.WriteLine("Protected Internal Demo");
    }

    private protected void PrivateProtectedDemo()
    {
        Console.WriteLine("Private Protected Demo");
    }

    public void run()
    {
        PublicDemo();
        PrivateDemo();
        ProtectedDemo();
        InternalDemo();
        ProtectedInternalDemo();
        PrivateProtectedDemo();
    }
}
