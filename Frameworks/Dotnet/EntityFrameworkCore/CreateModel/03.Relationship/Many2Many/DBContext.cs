using Relationship.Many2Many.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Relationship.Many2Many;

public partial class DBContext : DbContext
{
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Profile> Profiles { get; set; }
    public DBContext()
    { }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("server=LAPTOP-F2QSIV4N;database=RelationshipDemo;Integrated Security=True;trusted_connection=true;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    }
}