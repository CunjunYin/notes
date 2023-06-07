namespace Relationship.One2One.Required;

// Dependent (child)
public class Profile
{
    public int Id { get; set; }
    public int Age { get; set; }
    public int AuthorId { get; set; }// Required foreign key property
    public Author Author { get; set; }// Required reference navigation to principal
}