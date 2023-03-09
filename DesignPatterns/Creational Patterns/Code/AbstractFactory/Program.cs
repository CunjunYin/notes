using AbstractFactory.AbstractFactory;
using AbstractFactory.ConcreteFactory;

namespace AbstractFactory;
public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 1)
        {
            string OS = args[0];
            FurnitureAbstractFactory furniture;
            if (OS == "traditional") // dotnet run traditional
            {
                furniture = new TraditionalFurnitureFactory();
            }
            else// dotnet run modern
            {
                furniture = new ModernFurnitureFactory();
            }

            Console.WriteLine(furniture.getChair().height());
            Console.WriteLine(furniture.getDesk().color());
        }
    }
}
