using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTypes.Model.Configuration;

public class IgnoredEntityConfiguration : IEntityTypeConfiguration<IgnoredEntity>
{
    public void Configure(EntityTypeBuilder<IgnoredEntity> builder)
    {

    }
}