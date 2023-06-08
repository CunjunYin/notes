using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inheritance.Model.TablePerType;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable(nameof(Blog));
    }
}

public class RssBlogConfiguration : IEntityTypeConfiguration<RssBlog>
{
    public void Configure(EntityTypeBuilder<RssBlog> builder)
    {
        builder.ToTable(nameof(RssBlog));
    }
}