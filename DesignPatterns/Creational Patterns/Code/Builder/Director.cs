using Builder.Builder;

namespace Builder;

public class Director
{
    private IBuilder _builder;

    public IBuilder Builder
    {
        get { return _builder; }
        set { _builder = value; }
    }

    public void BuildCar()
    {
        this._builder.CreateVehicle();
        this._builder.BuildEngine("front whell driving");
        this._builder.BuildSeats(4);
        this._builder.BuildWhells(4);
    }

    public void BuildSportCar()
    {
        this._builder.CreateVehicle();
        this._builder.BuildEngine("4 whell driving");
        this._builder.BuildSeats(2);
        this._builder.BuildWhells(4);
        this._builder.BuildLeather();
    }
}