namespace AutoMapperDemo.Models;

public class ProjectionModel : SrcModel
{
    public DateTime EventDate { get; set; }
    public int EventHour { get; set; }
    public int EventMinute { get; set; }
}