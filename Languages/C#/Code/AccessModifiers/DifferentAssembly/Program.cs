
using SameAssembly.Access;
namespace DifferentAssembly;
using DifferentAssembly.AccessExtension;
class Program
{
    static void Main(string[] args)
    {
        AccessDemoExtension demo = new AccessDemoExtension();
        // AccessDemo demo = new AccessDemo();
        // demo.PublicDemo();
        // demo.PrivateDemo();  Inaccessible due to its protection level
        // demo.ProtectedDemo(); Inaccessible due to its protection level
        // demo.InternalDemo();
        // demo.ProtectedInternalDemo();
        // demo.PrivateProtectedDemo(); Inaccessible due to its protection level
    }
}