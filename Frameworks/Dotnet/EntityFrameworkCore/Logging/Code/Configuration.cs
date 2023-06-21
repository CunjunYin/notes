using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Code;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).IsRequired();
        builder.HasOne(b => b.author).WithOne(a => a.OwnedBlog);
        builder.HasMany(b => b.Posts).WithOne(p => p.Blog).HasForeignKey(p => p.BlogId).OnDelete(DeleteBehavior.SetNull);
    }
}

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Title).IsRequired();
        builder.Property(p => p.Content).IsRequired();
    }
}

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired();
        builder.HasMany(a => a.Posts).WithOne(p => p.Author);
    }
}