using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTypes.Model.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(student => student.Id);
        builder.Property(student => student.Name).IsRequired().HasMaxLength(100);
        builder.ToTable("T_Student"); // Table name
        builder.Property(student => student.Name).HasColumnName("StudentName"); // Change column name
    }
}