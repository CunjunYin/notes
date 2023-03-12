using AbstractFactory.Furniture;
namespace AbstractFactory.Furniture.Traditional;
public class TraditionalDesk : Desk
{
    public string color()
    {
        return "brown";
    }
}
