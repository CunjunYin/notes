using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Models.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(course => course.Id);
        builder.Property(course => course.Name).IsRequired().HasMaxLength(100);

        //  Without entity
        //builder.HasMany(course => course.Students)
        //    .WithMany(student => student.Courses)
        //    .UsingEntity<Dictionary<string, object>>(
        //        "StudentCourse",
        //        right => right.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
        //        left => left.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
        //        join => join.ToTable("StudentCourse").HasKey("StudentId", "CourseId").IsClustered()
        //    );

        //  With entity 
        //builder.HasMany(course => course.Students)
        //    .WithMany(student => student.Courses)
        //    .UsingEntity<StudentCourse>(
        //        right => right.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
        //        left => left.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
        //        join => join.ToTable("StudentCourse").HasKey("StudentId", "CourseId")
        //    );
    }
}