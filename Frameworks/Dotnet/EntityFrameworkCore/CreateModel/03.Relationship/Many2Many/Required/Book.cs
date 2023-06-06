namespace Relationship.Many2Many.Required;

public class Book
{
    public int Id { get; set; }
    public string BookName { get; set; }
    public ICollection<User> users { get; set; } = new List<User>();
}