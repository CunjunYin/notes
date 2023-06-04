namespace Relationship.One2Many;

// Principal (parent)
public class Profile
{
    public int Id { get; set; }
    public int Age { get; set; }
    public Author? Author { get; set; }// Reference navigation to dependent
}