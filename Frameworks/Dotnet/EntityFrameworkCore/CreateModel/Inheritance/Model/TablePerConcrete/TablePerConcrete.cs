using Microsoft.EntityFrameworkCore;

namespace Inheritance.Model.TablePerConcrete;

public abstract class BlogBase
{
    public int Id { get; set; }
    public string Url { get; set; }
}

public class Blog : BlogBase
{
}

public class RssBlog : BlogBase
{
    public string RssUrl { get; set; }
}

internal class TablePerConcrete : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<RssBlog> RssBlogs { get; set; }

    public TablePerConcrete()
    { }

    public TablePerConcrete(DbContextOptions<TablePerConcrete> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("server=LAPTOP-F2QSIV4N;database=Inheritance;Integrated Security=True;trusted_connection=true;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BlogConfiguration());
        builder.ApplyConfiguration(new RssBlogConfiguration());
    }
}