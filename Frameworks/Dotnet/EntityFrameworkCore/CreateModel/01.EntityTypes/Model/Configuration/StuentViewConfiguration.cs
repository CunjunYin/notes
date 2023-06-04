using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTypes.Model.Configuration;

public class StuentViewConfiguration : IEntityTypeConfiguration<StudentView>
{
    public void Configure(EntityTypeBuilder<StudentView> builder)
    {
        builder.HasNoKey().ToView("FulltimeStuentView");
        builder.Property(student => student.Name);
        builder.Property(student => student.NameLength);
    }
}