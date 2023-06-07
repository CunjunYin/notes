using Relationship.Many2Many.Required.Configuration;
using Microsoft.EntityFrameworkCore;
using Relationship.Many2Many.Required;

namespace Relationship.Many2Many;

public partial class Many2ManyDBContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public Many2ManyDBContext()
    { }

    public Many2ManyDBContext(DbContextOptions<Many2ManyDBContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("server=LAPTOP-F2QSIV4N;database=RelationshipDemo;Integrated Security=True;trusted_connection=true;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BookConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
    }
}