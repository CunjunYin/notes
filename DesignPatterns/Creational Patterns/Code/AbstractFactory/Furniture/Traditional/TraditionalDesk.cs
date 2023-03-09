using AbstractFactory.Furniture;
namespace AbstractFactory.Furniture.Traditional;
internal class TraditionalDesk : Desk
{
    public override string color()
    {
        return "brown";
    }
}
