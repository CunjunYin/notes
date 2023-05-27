using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Models.Configuration;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(userProfile => userProfile.Id);
        builder.Property(userProfile => userProfile.Address).IsRequired().HasMaxLength(200);
        builder.Property(userProfile => userProfile.Phone).IsRequired().HasMaxLength(20);

        // One to One Relationship: Each User can only have one User profile
        builder.HasOne<User>(up => up.User)
            .WithOne(u => u.UserProfile)
            .HasForeignKey<UserProfile>(up => up.UserID);
    }
}