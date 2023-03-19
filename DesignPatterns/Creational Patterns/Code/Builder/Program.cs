using Builder.Builder;

namespace Builder;
public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 1)
        {
            string car = args[0];
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            if (car == "sport") // dotnet run traditional
            {
                director.BuildSportCar();
            }
            else// dotnet run modern
            {
                director.BuildCar();
            }

            Console.WriteLine(director.Builder.vehicle.ToString());
        }
    }
}
