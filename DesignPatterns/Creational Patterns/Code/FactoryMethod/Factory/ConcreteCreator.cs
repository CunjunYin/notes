using FactoryMethod.Device;
namespace FactoryMethod.Factory;

public class LaptopFactroy: DeviceFactory
{
    protected override IDevice MakeDevice()
    {
        IDevice product = new LaptopDevice();
        return product;
    }
}

public class MobileFactroy : DeviceFactory
{
    protected override IDevice MakeDevice()
    {
        IDevice product = new MobileDevice();
        return product;
    }
}

public class WatchFactroy : DeviceFactory
{
    protected override IDevice MakeDevice()
    {
        IDevice product = new WatchDevice();
        return product;
    }
}
