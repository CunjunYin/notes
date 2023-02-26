using SameAssembly.Access;
namespace SameAssembly.AccessExtension;
internal class AccessDemoExtension: AccessDemo
{
    public AccessDemoExtension()
    {
        PublicDemo();
        // demo.PrivateDemo();  Inaccessible due to its protection level
        ProtectedDemo();
        InternalDemo();
        ProtectedInternalDemo();
        PrivateProtectedDemo();
    }
}
