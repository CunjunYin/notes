using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Relationship.One2One.Required.Configuration;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        //builder.HasOne(profile => profile.Author)
        //    .WithOne(author => author.Profile)
        //    .HasForeignKey<Profile>(profile => profile.AuthorId);
    }
}