namespace Relationship.Many2Many.Required;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public ICollection<Book> books { get; set; } = new List<Book>();
}