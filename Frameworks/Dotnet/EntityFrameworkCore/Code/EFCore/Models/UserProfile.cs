namespace EFCore.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public int UserID { get; set; }
    public User User { get; set; }
}