using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code;

internal class Event : DBContext
{
    public DbSet<Entity> Entities { get; set; }

    public static readonly ILoggerFactory loggerFactory
        = LoggerFactory.Create(
            builder =>
            {
                builder
                    .AddFilter(
                        (category, level) =>
                            category == DbLoggerCategory.Database.Command.Name
                            && level == LogLevel.Information)
                    .AddConsole();
            });

    public Event()
    {
        ChangeTracker.StateChanged += UpdateTimestamps;
        ChangeTracker.Tracked += UpdateTimestamps;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("server=LAPTOP-F2QSIV4N;database=Logging;Integrated Security=True;trusted_connection=true;TrustServerCertificate=Yes");
        builder.UseLoggerFactory(loggerFactory);
    }

    private static void UpdateTimestamps(object sender, EntityEntryEventArgs e)
    {
        if (e.Entry.Entity is IHasTimestamps entityWithTimestamps)
        {
            switch (e.Entry.State)
            {
                case EntityState.Deleted:
                    entityWithTimestamps.Deleted = DateTime.UtcNow;
                    Console.WriteLine($"Stamped for delete: {e.Entry.Entity}");
                    break;

                case EntityState.Modified:
                    entityWithTimestamps.Modified = DateTime.UtcNow;
                    Console.WriteLine($"Stamped for update: {e.Entry.Entity}");
                    break;

                case EntityState.Added:
                    entityWithTimestamps.Added = DateTime.UtcNow;
                    Console.WriteLine($"Stamped for insert: {e.Entry.Entity}");
                    break;
            }
        }
    }
}

public static class HasTimestampsExtensions
{
    public static string ToStampString(this IHasTimestamps entity)
    {
        return $"{GetStamp("Added", entity.Added)}{GetStamp("Modified", entity.Modified)}{GetStamp("Deleted", entity.Deleted)}";

        string GetStamp(string state, DateTime? dateTime)
            => dateTime == null ? "" : $" {state} on: {dateTime}";
    }
}

public interface IHasTimestamps
{
    DateTime? Added { get; set; }
    DateTime? Deleted { get; set; }
    DateTime? Modified { get; set; }
}

public class Entity : IHasTimestamps
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime? Added { get; set; }
    public DateTime? Deleted { get; set; }
    public DateTime? Modified { get; set; }

    public override string ToString()
        => $"Blog {Id}{this.ToStampString()}";
}