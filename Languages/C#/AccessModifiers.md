# Access Modifiers
| Modifier           |      Description             |
|--------------------|:-----------------------------|
| public             | Can be accessed by any code within/not within assembly  |
| private            | Can be only accessed by code within the same class or struct |
| protected          | Can be accessed only by code in the same class, or in a class that is derived from that class |
| internal           | Can be accessed by any code in the same assembly, but not from another assembly |
| protected internal | Can be accessed by any code in the same assembly, or from within a derived class in another assembly |
| Private protected  | Can be accessed by any code in the assembly in which it's declared, or from within a derived class in another assembly |

# Example

### Demo Package 
```cs
namespace SameAssembly.Access;
public class AccessDemo
{
    private void Demo(){}

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
```

### Same Assembly with reference
```cs
using SameAssembly.Access;
namespace Demo;
class Program
{
    static void Main(string[] args)
    {
        AccessDemo demo = new AccessDemo();
        demo.PublicDemo();
        // demo.PrivateDemo();  Inaccessible due to its protection level
        // demo.ProtectedDemo(); Inaccessible due to its protection level
        demo.InternalDemo();
        demo.ProtectedInternalDemo();
        // demo.PrivateProtectedDemo(); Inaccessible due to its protection level
    }
}
```

### Same Assembly with reference and derived
```cs
using SameAssembly.Access;
namespace SameAssembly.AccessExtension;
public class AccessDemoExtension: AccessDemo
{
    public AccessDemoExtension()
    {
        PublicDemo();
        // PrivateDemo();  Inaccessible due to its protection level
        ProtectedDemo();
        InternalDemo();
        ProtectedInternalDemo();
        PrivateProtectedDemo();
    }
}
```

### Different Assembly with reference
```cs
using SameAssembly.Access;
namespace DifferentAssembly;
class Program
{
    static void Main(string[] args)
    {
        AccessDemo demo = new AccessDemo();
        demo.PublicDemo();
        // demo.PrivateDemo();  Inaccessible due to its protection level
        // demo.ProtectedDemo(); Inaccessible due to its protection level
        // demo.InternalDemo();
        // demo.ProtectedInternalDemo();
        // demo.PrivateProtectedDemo(); Inaccessible due to its protection level
    }
}
```

### Different Assembly with reference and derived
```cs
using SameAssembly.Access;
namespace DifferentAssembly.AccessExtension;
internal class AccessDemoExtension : AccessDemo
{
    public AccessDemoExtension()
    {
        PublicDemo();
        // demo.PrivateDemo();  Inaccessible due to its protection level
        ProtectedDemo();
        // InternalDemo(); Inaccessible due to its protection level
        ProtectedInternalDemo();
        // PrivateProtectedDemo(); Inaccessible due to its protection level
    }
}
```
