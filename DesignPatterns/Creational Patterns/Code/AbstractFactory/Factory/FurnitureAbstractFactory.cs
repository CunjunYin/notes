using AbstractFactory.Furniture;
namespace AbstractFactory.AbstractFactory;
public abstract class FurnitureAbstractFactory
{
    public abstract Desk getDesk();
    public abstract Chair getChair();
}
