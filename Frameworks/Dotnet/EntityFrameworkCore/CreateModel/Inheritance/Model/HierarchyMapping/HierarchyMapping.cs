using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Inheritance.Model.HierarchyMapping;

internal class HierarchyMapping : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<RssBlog> RssBlogs { get; set; }

    public HierarchyMapping()
    { }

    public HierarchyMapping(DbContextOptions<HierarchyMapping> options) : base(options)
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

public class Blog
{
    public int Id { get; set; }
    public string Url { get; set; }

    // SELECT[b].[BlogId], [b].[Discriminator], [b].[Url], [b].[RssUrl] FROM[Blogs] AS[b]
    // www.blog.com
    // www.blog.com
}

public class RssBlog : Blog
{
    // SELECT[b].[BlogId], [b].[Discriminator], [b].[Url], [b].[RssUrl] FROM [Blogs] AS [b]  WHERE [b].[Discriminator] = N'RssBlog'
    // www.blog.com, www.rssblog.com
    public string RssUrl { get; set; }
}