using AbstractFactory.Furniture;
namespace AbstractFactory.Furniture.Modern;

public class ModernChair: Chair
{
    public override int height()
    {
        return 75;
    }
}
