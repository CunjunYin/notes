using Builder.Vehicle;

namespace Builder.Builder;

internal class ConcreteBuilder : IBuilder
{
    public IVehicle vehicle { get; set; }
    public void BuildEngine(string engine)
    {
        if (vehicle == null)
        {
            throw new NullReferenceException("vehicle not initializaed");
        }

        vehicle.engine = engine;
    }

    public void BuildSeats(int seats)
    {
        if (vehicle == null)
        {
            throw new NullReferenceException("vehicle not initializaed");
        }

        vehicle.seats = seats;
    }

    public void BuildWhells(int whells)
    {
        if (vehicle == null)
        {
            throw new NullReferenceException("vehicle not initializaed");
        }

        vehicle.whells = whells;
    }

    public void BuildLeather()
    {
        if (vehicle == null)
        {
            throw new NullReferenceException("vehicle not initializaed");
        }
        vehicle.leather = true;
    }

    public void CreateVehicle()
    {
        vehicle = new Vehicle.Vehicle();
    }
}
