using EntityTypes.Model.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EntityTypes.Model;

public partial class DBContext : DbContext
{
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<StudentView> StudentsView { get; set; }
    public virtual DbSet<StudentFunction> StudentsFunction { get; set; }
    public virtual DbSet<IgnoredEntity> IgnoredEntities { get; set; }
    public DBContext()
    { }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("server=LAPTOP-F2QSIV4N;database=CreateModelDemo;Integrated Security=True;trusted_connection=true;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("CreateModelDemo");
        builder.Ignore<IgnoredEntity>();
        builder.ApplyConfiguration<Student>(new StudentConfiguration());
        builder.ApplyConfiguration<StudentFunction>(new StuentFunctionConfiguration());
        builder.ApplyConfiguration<StudentView>(new StuentViewConfiguration());
    }
}