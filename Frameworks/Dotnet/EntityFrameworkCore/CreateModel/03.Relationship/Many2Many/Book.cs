namespace Relationship.Many2Many;

// Principal (parent)
public class Book
{
    public int Id { get; set; }
    public string BookName { get; set; }
    public ICollection<Author> authors { get; set; } // Reference navigation to dependent
    public ICollection<User> users { get; set; }
}