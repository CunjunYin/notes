namespace Builder.Vehicle;

public class Vehicle: IVehicle
{
    public string engine { get; set; }
    public int seats { get; set; }
    public int whells { get; set; }
    public bool leather { get; set; } = false;
    
    public Vehicle(){}

    public override string ToString()
    {
        return string.Format("{0}, {1}, {2}, {3}", engine, seats, whells, leather);
    }
}
