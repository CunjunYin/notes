namespace EntityTypes.Model;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Courses { get; set; }
    public string ExcludedString { get; set; } // This type should be excluded
}