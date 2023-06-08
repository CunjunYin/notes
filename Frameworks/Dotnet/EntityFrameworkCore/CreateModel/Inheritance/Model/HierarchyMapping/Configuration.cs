using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Model.HierarchyMapping;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasDiscriminator<string>("blog_type")
        .HasValue<Blog>("blog_base")
        .HasValue<RssBlog>("blog_rss");

        builder.Property("blog_type").HasMaxLength(200);
    }
}

public class RssBlogConfiguration : IEntityTypeConfiguration<RssBlog>
{
    public void Configure(EntityTypeBuilder<RssBlog> builder)
    {

    }
}
