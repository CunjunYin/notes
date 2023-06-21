using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code.EKR;

public static class ExplicitKeysRequired
{
    public static void Deleting_principal_parent_entities_1()
    {
        Console.WriteLine($">>>> Sample: {nameof(Deleting_principal_parent_entities_1)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        using var context = new BlogsContext();

        var blog = GetDisconnectedBlogAndPosts();

        #region Deleting_principal_parent_entities_1

        // Attach a blog and associated posts
        context.Attach(blog);

        // Mark the blog as deleted
        context.Remove(blog);

        #endregion Deleting_principal_parent_entities_1

        Console.WriteLine("Before SaveChanges:");
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        context.SaveChanges();

        Console.WriteLine("After SaveChanges:");
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        Console.WriteLine();

        Blog GetDisconnectedBlogAndPosts()
        {
            using var tempContext = new BlogsContext();
            return tempContext.Blogs.Include(e => e.Posts).Single();
        }
    }
}

public static class Helpers
{
    public static void RecreateCleanDatabase()
    {
        using (var context = new BlogsContext(quiet: true))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }

    public static void PopulateDatabase()
    {
        using (var context = new BlogsContext(quiet: true))
        {
            context.Add(
                new Blog
                {
                    Id = 1,
                    Name = ".NET Blog",
                    Posts =
                    {
                    new Post
                    {
                        Id = 1,
                        Title = "Announcing the Release of EF Core 5.0",
                        Content = "Announcing the release of EF Core 5.0, a full featured cross-platform..."
                    },
                    new Post
                    {
                        Id = 2,
                        Title = "Announcing F# 5",
                        Content = "F# 5 is the latest version of F#, the functional programming language..."
                    },
                    }
                });

            context.SaveChanges();
        }
    }
}

#region Model

public class Blog
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public string Name { get; set; }

    public IList<Post> Posts { get; } = new List<Post>();
}

public class Post
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}

#endregion Model

public class BlogsContext : DbContext
{
    private readonly bool _quiet;

    public BlogsContext(bool quiet = false)
    {
        _quiet = quiet;
    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging()
            .UseSqlServer("server=LAPTOP-F2QSIV4N;database=Tracking;Integrated Security=True;trusted_connection=true;TrustServerCertificate=Yes");

        if (!_quiet)
        {
            optionsBuilder.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
        }
    }
}