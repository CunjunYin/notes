namespace Builder.Vehicle;

public interface IVehicle
{
    public string engine { get; set; }
    public int seats { get; set; }
    public int whells { get; set; }
    public bool leather { get; set; }
}
