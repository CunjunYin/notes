using Microsoft.EntityFrameworkCore;

namespace Code;

public class DBContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Author> Authors { get; set; }

    public DBContext()
    { }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BlogConfiguration());
        builder.ApplyConfiguration(new PostConfiguration());
        builder.ApplyConfiguration(new AuthorConfiguration());
    }
}