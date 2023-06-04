using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityProperties.Model.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(student => student.Id);
        builder.Property(student => student.Name).IsRequired().HasMaxLength(100);
        builder.Ignore(student => student.ExcludedString); // Exclude
        builder.ToTable("T_Student"); // Table name
        builder.Property(student => student.Name).HasColumnName("StudentName"); // Change column name
        builder.Property(student => student.Courses).HasColumnOrder(0);
    }
}