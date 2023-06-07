using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Relationship.One2One.Required.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasOne(author => author.Profile)
            .WithOne(profile => profile.Author)
            .HasForeignKey<Profile>(profile => profile.AuthorId);
    }
}