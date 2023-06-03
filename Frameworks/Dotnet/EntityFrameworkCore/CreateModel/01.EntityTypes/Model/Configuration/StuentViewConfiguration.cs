using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTypes.Model.Configuration;

public class StuentViewConfiguration : IEntityTypeConfiguration<StudentView>
{
    public void Configure(EntityTypeBuilder<StudentView> builder)
    {
        builder.HasNoKey().ToView("FulltimeStuentView");
        builder.Property(student => student.Name).HasColumnName("StudentName");
        builder.Property(student => student.NameLength).HasColumnName("len_name");
    }
}