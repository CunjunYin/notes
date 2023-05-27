using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Models.Configuration;

public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.HasKey(studentCourse => new { studentCourse.StudentID, studentCourse.CourseID });

        builder.HasOne(studentCourse => studentCourse.Student)
            .WithMany(student => student.StudentCourses)
            .HasForeignKey(studentCourse => studentCourse.StudentID);

        builder.HasOne(studentCourse => studentCourse.Course)
            .WithMany(course => course.StudentCourses)
            .HasForeignKey(studentCourse => studentCourse.CourseID);
    }
}