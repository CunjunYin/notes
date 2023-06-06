namespace Relationship.One2Many.Required;

// Dependent (child)
public class Book
{
    public int Id { get; set; }
    public string BookName { get; set; }
    public int AuthorID { get; set; }
    public Author Author { get; set; }
}