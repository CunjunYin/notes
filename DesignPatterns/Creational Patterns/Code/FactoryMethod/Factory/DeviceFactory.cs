using FactoryMethod.Device;
namespace FactoryMethod.Factory;

public abstract class DeviceFactory
{
    protected abstract IDevice MakeDevice();
    public IDevice CreateDevice()
    {
        return this.MakeDevice();
    }
}
