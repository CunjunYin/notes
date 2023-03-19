using Builder.Vehicle;

namespace Builder.Builder;

public interface IBuilder
{
    public IVehicle vehicle { get; set; }
    public void CreateVehicle();

    public void BuildEngine(string cpu);

    public void BuildSeats(int seats);

    public void BuildWhells(int whells);
    public void BuildLeather();
}
