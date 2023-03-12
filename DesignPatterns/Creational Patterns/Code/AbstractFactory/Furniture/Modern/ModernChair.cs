using AbstractFactory.Furniture;
namespace AbstractFactory.Furniture.Modern;

public class ModernChair: Chair
{
    public int height()
    {
        return 75;
    }
}
