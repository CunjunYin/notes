using Microsoft.EntityFrameworkCore;
using Relationship.One2One.Required.Configuration;
using Relationship.One2One.Required;

namespace Relationship.One2One;

public partial class One2OneDBContext : DbContext
{
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Profile> Profiles { get; set; }

    public One2OneDBContext()
    { }

    public One2OneDBContext(DbContextOptions<One2OneDBContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("server=LAPTOP-F2QSIV4N;database=RelationshipDemo;Integrated Security=True;trusted_connection=true;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AuthorConfiguration());
        builder.ApplyConfiguration(new ProfileConfiguration());
    }
}