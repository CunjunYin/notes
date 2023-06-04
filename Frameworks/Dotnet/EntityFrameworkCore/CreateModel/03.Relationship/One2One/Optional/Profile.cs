namespace Relationship.One2One.Optional;

// Principal (parent)
public class Profile
{
    public int Id { get; set; }
    public int Age { get; set; }
    public int? AuthorId { get; set; }// Required foreign key property
    public Author? Author { get; set; }// Reference navigation to dependent
}