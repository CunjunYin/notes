using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityProperties.Model.Configuration;

public class StuentFunctionConfiguration : IEntityTypeConfiguration<StudentFunction>
{
    public void Configure(EntityTypeBuilder<StudentFunction> builder)
    {
        builder.HasNoKey().ToFunction("FulltimeStudentFunction");
        builder.Property(student => student.Name).HasColumnName("StudentName");
        builder.Property(student => student.NameLength).HasColumnName("len_name");
    }
}