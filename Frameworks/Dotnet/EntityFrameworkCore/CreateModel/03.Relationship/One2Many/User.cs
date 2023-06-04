namespace Relationship.One2Many;

// Principal (parent)
public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public ICollection<Book> books { get; set; }// Reference navigation to dependent
}