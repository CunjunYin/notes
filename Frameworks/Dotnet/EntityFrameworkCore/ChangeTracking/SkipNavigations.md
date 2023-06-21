# Skip navigations
In EF Core, skip navigations are a feature that allows you to define relationships between entities through intermediate entities without explicitly creating a direct navigation property. Skip navigations enable you to navigate between entities in a more indirect manner.

```csharp
public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }

    public List<StudentCourse> StudentCourses { get; set; }
}

public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; }

    public List<StudentCourse> StudentCourses { get; set; }
}

// intermediate entity between Student and Course
public class StudentCourse
{
    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }
}

// The Student and Course entities have a many-to-many relationship through the StudentCourse entity.
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<StudentCourse>()
        .HasKey(sc => new { sc.StudentId, sc.CourseId });

    modelBuilder.Entity<StudentCourse>()
        .HasOne<Student>(sc => sc.Student)
        .WithMany()
        .HasForeignKey(sc => sc.StudentId);

    modelBuilder.Entity<StudentCourse>()
        .HasOne<Course>(sc => sc.Course)
        .WithMany()
        .HasForeignKey(sc => sc.CourseId);
}
```

**Skip navigations**
```csharp
// Query
using (var context = new YourDbContext())
{
    var student = context.Students.Include(s => s.StudentCourses).FirstOrDefault();
    foreach (var studentCourse in student.StudentCourses)
    {
        var course = studentCourse.Course;
        // Access the related course through the skip navigation.
    }
}

// Insert
using (var context = new YourDbContext())
{
    // var student = ...
    // var course = ...
    context.Add(new PostTag { Student=student, Course = course});
}
```