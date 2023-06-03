using EFCore.Models.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Models;

public partial class DBContext : DbContext
{
    public DBContext()
    { }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Student> Students { get; set; }

    // public virtual DbSet<StudentCourse> StudentCourses { get; set; }
    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("server=LAPTOP-F2QSIV4N;database=SchoolDB;Integrated Security=True;trusted_connection=true;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration<Course>(new CourseConfiguration());
        builder.ApplyConfiguration<Department>(new DepartmentConfiguration());
        builder.ApplyConfiguration<Employee>(new EmployeeConfiguration());
        builder.ApplyConfiguration<Student>(new StudentConfiguration());
        builder.ApplyConfiguration<StudentCourse>(new StudentCourseConfiguration());
        builder.ApplyConfiguration<User>(new UserConfiguration());
        builder.ApplyConfiguration<UserProfile>(new UserProfileConfiguration());
       
    }
}