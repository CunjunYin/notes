using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inheritance.Model.TablePerConcrete;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.UseTpcMappingStrategy().ToTable(nameof(Blog));
    }
}

public class RssBlogConfiguration : IEntityTypeConfiguration<RssBlog>
{
    public void Configure(EntityTypeBuilder<RssBlog> builder)
    {
        builder.UseTpcMappingStrategy().ToTable(nameof(RssBlog));
    }
}