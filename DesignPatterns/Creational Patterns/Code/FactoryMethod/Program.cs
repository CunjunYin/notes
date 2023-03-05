using FactoryMethod.Factory;
namespace FactoryMethod;
public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 1)
        {
            string OS = args[0];
            IDevice device;
            if (OS == "laptop")
            {
                device = new LaptopFactroy().CreateDevice();
                device.DeviceType();
            }

            else if (OS == "mobile")
            {
                device = new MobileFactroy().CreateDevice();
                device.DeviceType();
            }

            else
            {
                device = new WatchFactroy().CreateDevice();
                device.DeviceType();
            }
        }
    }
}
