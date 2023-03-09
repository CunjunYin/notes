using AbstractFactory.AbstractFactory;
using AbstractFactory.Furniture;
using AbstractFactory.Furniture.Modern;
using AbstractFactory.Furniture.Traditional;

namespace AbstractFactory.ConcreteFactory;

public class ModernFurnitureFactory: FurnitureAbstractFactory
{
    public override Desk getDesk()
    {
        return new ModernDesk();
    }
    public override Chair getChair()
    {
        return new ModernChair();
    }
}

public class TraditionalFurnitureFactory : FurnitureAbstractFactory
{
    public override Desk getDesk()
    {
        return new TraditionalDesk();
    }
    public override Chair getChair()
    {
        return new TraditionalChair();
    }
}