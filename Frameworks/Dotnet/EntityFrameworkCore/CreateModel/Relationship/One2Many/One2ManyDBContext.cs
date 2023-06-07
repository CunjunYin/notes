using Relationship.One2Many.Required.Configuration;
using Microsoft.EntityFrameworkCore;
using Relationship.One2Many.Required;
using System.Linq.Expressions;

namespace Relationship.One2Many;

public partial class One2ManyDBContext : DbContext
{
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public One2ManyDBContext()
    { }

    public One2ManyDBContext(DbContextOptions<One2ManyDBContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("server=LAPTOP-F2QSIV4N;database=RelationshipDemo;Integrated Security=True;trusted_connection=true;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BookConfiguration());
        builder.ApplyConfiguration(new AuthorConfiguration());
    }
}