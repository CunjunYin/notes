using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;
using System;
using System.Text.Json;

namespace BackingFields.Model;

public class DBContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<FieldOnlyBlog> FieldOnlyBlogs { get; set; }

    public DBContext()
    { }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("server=LAPTOP-F2QSIV4N;database=BackingFields;Integrated Security=True;trusted_connection=true;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BlogConfiguration());
        builder.ApplyConfiguration(new FieldOnlyBlogConfiguration());
    }
}

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.Property(b => b.Url)
        .HasField("_url");
        builder.Property(b => b.ListInts).HasConversion(
            ListInts => JsonSerializer.Serialize(ListInts, (JsonSerializerOptions)null),
            ListInts => JsonSerializer.Deserialize<List<int>>(ListInts, (JsonSerializerOptions)null),
            new ValueComparer<List<int>>
            (
                // Equals Expression,
                (ListInts1, ListInts2) => ListInts1.SequenceEqual(ListInts2),

                // Hash Code Expression
                ListInts => ListInts.Aggregate(0, (ListInts, v) => HashCode.Combine(ListInts, v.GetHashCode())),

                // Snapshot Expression
                c => c.ToList()
            )
        );
    }
}

public class FieldOnlyBlogConfiguration : IEntityTypeConfiguration<FieldOnlyBlog>
{
    public void Configure(EntityTypeBuilder<FieldOnlyBlog> builder)
    {
        builder.Property("_url");
    }
}


public class Blog
{
    private string _url;

    public int Id { get; set; }

    public List<int> ListInts { get; set; }

    public string Url
    {
        get { return _url + "Hello"; }
        set { _url = value+"/"; }
    }
}

public class FieldOnlyBlog
{
    private string _url;

    public int Id { get; set; }

    public string GetUrl()
    {
        return _url + "hello";
    }

    public void SetUrl(string value)
    {
        _url = value + "/";
    }
}