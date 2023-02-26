
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