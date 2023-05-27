namespace EFCore.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public UserProfile UserProfile { get; set; }
}