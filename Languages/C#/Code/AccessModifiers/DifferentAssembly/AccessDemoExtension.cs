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
