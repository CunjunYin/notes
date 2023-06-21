using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace Code.ACE;

public class AccessingTrackedEntities
{
    public static void Using_DbContext_Entry_and_EntityEntry_instances_1()
    {
        Console.WriteLine($">>>> Sample: {nameof(Using_DbContext_Entry_and_EntityEntry_instances_1)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        #region Using_DbContext_Entry_and_EntityEntry_instances_1

        using var context = new BlogsContext();

        var blog = context.Blogs.Single(e => e.Id == 1);
        var entityEntry = context.Entry(blog);

        #endregion Using_DbContext_Entry_and_EntityEntry_instances_1

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        Console.WriteLine();
    }

    public static void Work_with_the_entity_1()
    {
        Console.WriteLine($">>>> Sample: {nameof(Work_with_the_entity_1)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        using var context = new BlogsContext();

        var blog = context.Blogs.Single(e => e.Id == 1);

        #region Work_with_the_entity_1

        var currentState = context.Entry(blog).State;
        if (currentState == EntityState.Unchanged)
        {
            context.Entry(blog).State = EntityState.Modified;
        }

        #endregion Work_with_the_entity_1

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        context.SaveChanges();
        Console.WriteLine();
    }

    public static void Work_with_the_entity_2()
    {
        Console.WriteLine($">>>> Sample: {nameof(Work_with_the_entity_2)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        using var context = new BlogsContext();

        #region Work_with_the_entity_2

        var newBlog = new Blog();
        Debug.Assert(context.Entry(newBlog).State == EntityState.Detached);

        context.Entry(newBlog).State = EntityState.Added;
        Debug.Assert(context.Entry(newBlog).State == EntityState.Added);

        #endregion Work_with_the_entity_2

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        Console.WriteLine();
    }

    public static void Work_with_a_single_property_1()
    {
        Console.WriteLine($">>>> Sample: {nameof(Work_with_a_single_property_1)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        using var context = new BlogsContext();

        {
            var blog = context.Blogs.Single(e => e.Id == 1);

            #region Work_with_a_single_property_1a

            PropertyEntry<Blog, string> propertyEntry = context.Entry(blog).Property(e => e.Name);

            #endregion Work_with_a_single_property_1a
        }

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        Console.WriteLine();

        {
            var blog = context.Blogs.Single(e => e.Id == 1);

            #region Work_with_a_single_property_1b

            PropertyEntry<Blog, string> propertyEntry = context.Entry(blog).Property<string>("Name");

            #endregion Work_with_a_single_property_1b
        }

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        Console.WriteLine();

        {
            var blog = context.Blogs.Single(e => e.Id == 1);

            #region Work_with_a_single_property_1c

            PropertyEntry propertyEntry = context.Entry(blog).Property("Name");

            #endregion Work_with_a_single_property_1c
        }

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        Console.WriteLine();

        {
            var blog = context.Blogs.Single(e => e.Id == 1);

            #region Work_with_a_single_property_1d

            string currentValue = context.Entry(blog).Property(e => e.Name).CurrentValue;
            context.Entry(blog).Property(e => e.Name).CurrentValue = "1unicorn2";

            #endregion Work_with_a_single_property_1d
        }

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        Console.WriteLine();

        {
            #region Work_with_a_single_property_1e

            object blog = context.Blogs.Single(e => e.Id == 1);

            object currentValue = context.Entry(blog).Property("Name").CurrentValue;
            context.Entry(blog).Property("Name").CurrentValue = "1unicorn2";

            #endregion Work_with_a_single_property_1e
        }

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        Console.WriteLine();
    }

    public static void Work_with_a_single_navigation_1()
    {
        Console.WriteLine($">>>> Sample: {nameof(Work_with_a_single_navigation_1)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        using var context = new BlogsContext();

        var post = context.Posts.Include(e => e.Blog).Single(e => e.Id == 1);

        #region Work_with_a_single_navigation_1

        ReferenceEntry<Post, Blog> referenceEntry1 = context.Entry(post).Reference(e => e.Blog);
        ReferenceEntry<Post, Blog> referenceEntry2 = context.Entry(post).Reference<Blog>("Blog");
        ReferenceEntry referenceEntry3 = context.Entry(post).Reference("Blog");

        #endregion Work_with_a_single_navigation_1
        Console.WriteLine(
            referenceEntry3.CurrentValue == referenceEntry2.CurrentValue &&
            referenceEntry2.CurrentValue == referenceEntry2.CurrentValue);
        Console.WriteLine();
    }

    public static void Work_with_a_single_navigation_2()
    {
        Console.WriteLine($">>>> Sample: {nameof(Work_with_a_single_navigation_2)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        using var context = new BlogsContext();

        var blog = context.Blogs.Include(e => e.Posts).Single(e => e.Id == 1);

        #region Work_with_a_single_navigation_2a

        CollectionEntry<Blog, Post> collectionEntry1 = context.Entry(blog).Collection(e => e.Posts);
        CollectionEntry<Blog, Post> collectionEntry2 = context.Entry(blog).Collection<Post>("Posts");
        CollectionEntry collectionEntry3 = context.Entry(blog).Collection("Posts");

        #endregion Work_with_a_single_navigation_2a

        #region Work_with_a_single_navigation_2b

        NavigationEntry navigationEntry = context.Entry(blog).Navigation("Posts");

        #endregion Work_with_a_single_navigation_2b
        Console.WriteLine(
            collectionEntry3.CurrentValue == collectionEntry2.CurrentValue &&
            collectionEntry2.CurrentValue == collectionEntry1.CurrentValue
        );
        Console.WriteLine();
    }

    public static void Work_with_all_properties_of_an_entity_1()
    {
        Console.WriteLine($">>>> Sample: {nameof(Work_with_all_properties_of_an_entity_1)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        using var context = new BlogsContext();

        var blog = context.Blogs.Include(e => e.Posts).Single(e => e.Id == 1);

        #region Work_with_all_properties_of_an_entity_1

        foreach (var propertyEntry in context.Entry(blog).Properties)
        {
            if (propertyEntry.Metadata.ClrType == typeof(DateTime))
            {
                propertyEntry.CurrentValue = DateTime.Now;
            }
        }

        #endregion Work_with_all_properties_of_an_entity_1

        Console.WriteLine();
    }

    public static void Work_with_all_properties_of_an_entity_2()
    {
        Console.WriteLine($">>>> Sample: {nameof(Work_with_all_properties_of_an_entity_2)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        using var context = new BlogsContext();

        var blog = context.Blogs.Include(e => e.Posts).Single(e => e.Id == 1);

        {
            #region Work_with_all_properties_of_an_entity_2a

            var currentValues = context.Entry(blog).CurrentValues;
            var originalValues = context.Entry(blog).OriginalValues;
            var databaseValues = context.Entry(blog).GetDatabaseValues();

            #endregion Work_with_all_properties_of_an_entity_2a
        }

        {
            #region Work_with_all_properties_of_an_entity_2b

            var blogDto = new BlogDto { Id = 1, Name = "1unicorn2" };

            context.Entry(blog).CurrentValues.SetValues(blogDto);

            #endregion Work_with_all_properties_of_an_entity_2b
        }

        {
            #region Work_with_all_properties_of_an_entity_2c

            var databaseValues = context.Entry(blog).GetDatabaseValues();
            context.Entry(blog).CurrentValues.SetValues(databaseValues);
            context.Entry(blog).OriginalValues.SetValues(databaseValues);

            #endregion Work_with_all_properties_of_an_entity_2c
        }

        {
            #region Work_with_all_properties_of_an_entity_2d

            var blogDictionary = new Dictionary<string, object> { ["Id"] = 1, ["Name"] = "1unicorn2" };

            context.Entry(blog).CurrentValues.SetValues(blogDictionary);

            #endregion Work_with_all_properties_of_an_entity_2d
        }

        {
            #region Work_with_all_properties_of_an_entity_2e

            var clonedBlog = context.Entry(blog).GetDatabaseValues().ToObject();

            #endregion Work_with_all_properties_of_an_entity_2e
        }

        Console.WriteLine();
    }

    public static void Work_with_all_navigations_of_an_entity_1()
    {
        Console.WriteLine($">>>> Sample: {nameof(Work_with_all_navigations_of_an_entity_1)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        using var context = new BlogsContext();

        var blog = context.Blogs.Single(e => e.Id == 1);

        #region Work_with_all_navigations_of_an_entity_1

        var entry = context.Entry(blog);

        foreach (var navigationEntry in entry.Navigations)
        {
            navigationEntry.Load();
        }

        #endregion Work_with_all_navigations_of_an_entity_1

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        Console.WriteLine();
    }

    public static void Work_with_all_members_of_an_entity_1()
    {
        Console.WriteLine($">>>> Sample: {nameof(Work_with_all_members_of_an_entity_1)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        using var context = new BlogsContext();

        var blog = context.Blogs.Single(e => e.Id == 1);

        #region Work_with_all_members_of_an_entity_1
        var entry = context.Entry(blog);
        foreach (var memberEntry in entry.Members)
        {
            Console.WriteLine(
                $"Member {memberEntry.Metadata.Name} is of type {memberEntry.Metadata.ClrType.ShortDisplayName()} and has value {memberEntry.CurrentValue}");
        }

        #endregion Work_with_all_members_of_an_entity_1

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        Console.WriteLine();
    }

    public static void Find_and_FindAsync_1()
    {
        Console.WriteLine($">>>> Sample: {nameof(Find_and_FindAsync_1)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        #region Find_and_FindAsync_1

        using var context = new BlogsContext();

        Console.WriteLine("First call to Find...");
        var blog1 = context.Blogs.Find(1);

        Console.WriteLine($"...found blog {blog1.Name}");

        Console.WriteLine();
        Console.WriteLine("Second call to Find...");
        var blog2 = context.Blogs.Find(1);
        Debug.Assert(blog1 == blog2);

        Console.WriteLine("...returned the same instance without executing a query.");

        #endregion Find_and_FindAsync_1

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        Console.WriteLine();
    }

    public static void Find_and_FindAsync_2()
    {
        Console.WriteLine($">>>> Sample: {nameof(Find_and_FindAsync_2)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        using var context = new BlogsContext();
        var orderId = 1;
        var productId = 2;

        #region Find_and_FindAsync_2

        var orderline = context.OrderLines.Find(orderId, productId);

        #endregion Find_and_FindAsync_2

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        Console.WriteLine();
    }

    public static void Using_ChangeTracker_Entries_to_access_all_tracked_entities_1()
    {
        Console.WriteLine($">>>> Sample: {nameof(Using_ChangeTracker_Entries_to_access_all_tracked_entities_1)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        #region Using_ChangeTracker_Entries_to_access_all_tracked_entities_1a

        using var context = new BlogsContext();
        var blogs = context.Blogs.Include(e => e.Posts).ToList();

        foreach (var entityEntry in context.ChangeTracker.Entries())
        {
            Console.WriteLine($"Found {entityEntry.Metadata.Name} entity with ID {entityEntry.Property("Id").CurrentValue}");
        }

        #endregion Using_ChangeTracker_Entries_to_access_all_tracked_entities_1a

        Console.WriteLine();

        #region Using_ChangeTracker_Entries_to_access_all_tracked_entities_1b

        foreach (var entityEntry in context.ChangeTracker.Entries<Post>())
        {
            Console.WriteLine(
                $"Found {entityEntry.Metadata.Name} entity with ID {entityEntry.Property(e => e.Id).CurrentValue}");
        }

        #endregion Using_ChangeTracker_Entries_to_access_all_tracked_entities_1b

        Console.WriteLine();

        #region Using_ChangeTracker_Entries_to_access_all_tracked_entities_1c

        foreach (var entityEntry in context.ChangeTracker.Entries<IEntityWithKey>())
        {
            Console.WriteLine(
                $"Found {entityEntry.Metadata.Name} entity with ID {entityEntry.Property(e => e.Id).CurrentValue}");
        }

        #endregion Using_ChangeTracker_Entries_to_access_all_tracked_entities_1c

        Console.WriteLine();
    }

    public static void Using_DbSet_Local_to_query_tracked_entities_1()
    {
        Console.WriteLine($">>>> Sample: {nameof(Using_DbSet_Local_to_query_tracked_entities_1)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        #region Using_DbSet_Local_to_query_tracked_entities_1

        using var context = new BlogsContext();

        context.Blogs.Include(e => e.Posts).Load();

        foreach (var blog in context.Blogs.Local)
        {
            Console.WriteLine($"Blog: {blog.Name}");
        }

        foreach (var post in context.Posts.Local)
        {
            Console.WriteLine($"Post: {post.Title}");
        }

        #endregion Using_DbSet_Local_to_query_tracked_entities_1

        Console.WriteLine();
    }

    public static void Using_DbSet_Local_to_query_tracked_entities_2()
    {
        Console.WriteLine($">>>> Sample: {nameof(Using_DbSet_Local_to_query_tracked_entities_2)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        #region Using_DbSet_Local_to_query_tracked_entities_2

        using var context = new BlogsContext();

        var posts = context.Posts.Include(e => e.Blog).ToList();

        Console.WriteLine("Local view after loading posts:");

        foreach (var post in context.Posts.Local)
        {
            Console.WriteLine($"  Post: {post.Title}");
        }

        context.Remove(posts[1]);

        context.Add(
            new Post
            {
                Title = "What’s next for System.Text.Json?",
                Content = ".NET 5.0 was released recently and has come with many...",
                Blog = posts[0].Blog
            });

        Console.WriteLine("Local view after adding and deleting posts:");

        foreach (var post in context.Posts.Local)
        {
            Console.WriteLine($"  Post: {post.Title}");
        }

        #endregion Using_DbSet_Local_to_query_tracked_entities_2

        Console.WriteLine();
    }

    public static void Using_DbSet_Local_to_query_tracked_entities_3()
    {
        Console.WriteLine($">>>> Sample: {nameof(Using_DbSet_Local_to_query_tracked_entities_3)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        #region Using_DbSet_Local_to_query_tracked_entities_3

        using var context = new BlogsContext();

        var posts = context.Posts.Include(e => e.Blog).ToList();

        Console.WriteLine("Local view after loading posts:");

        foreach (var post in context.Posts.Local)
        {
            Console.WriteLine($"  Post: {post.Title}");
        }

        context.Posts.Local.Remove(posts[1]);

        context.Posts.Local.Add(
            new Post
            {
                Title = "What’s next for System.Text.Json?",
                Content = ".NET 5.0 was released recently and has come with many...",
                Blog = posts[0].Blog
            });

        Console.WriteLine("Local view after adding and deleting posts:");

        foreach (var post in context.Posts.Local)
        {
            Console.WriteLine($"  Post: {post.Title}");
        }

        #endregion Using_DbSet_Local_to_query_tracked_entities_3

        Console.WriteLine();
    }

    public static void Using_DbSet_Local_to_query_tracked_entities_4()
    {
        Console.WriteLine($">>>> Sample: {nameof(Using_DbSet_Local_to_query_tracked_entities_4)}");
        Console.WriteLine();

        Helpers.RecreateCleanDatabase();
        Helpers.PopulateDatabase();

        using var context = new BlogsContext();

        context.Posts.Include(e => e.Blog).Load();

        #region Using_DbSet_Local_to_query_tracked_entities_4

        ObservableCollection<Post> observableCollection = context.Posts.Local.ToObservableCollection();
        BindingList<Post> bindingList = context.Posts.Local.ToBindingList();

        #endregion Using_DbSet_Local_to_query_tracked_entities_4

        Console.WriteLine();
    }
}

public static class Helpers
{
    public static void RecreateCleanDatabase()
    {
        using var context = new BlogsContext(quiet: true);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    public static void PopulateDatabase()
    {
        using var context = new BlogsContext(quiet: true);

        context.Add(
            new Blog
            {
                Name = ".NET Blog",
                Posts =
                {
                    new Post
                    {
                        Title = "Announcing the Release of EF Core 5.0",
                        Content = "Announcing the release of EF Core 5.0, a full featured cross-platform..."
                    },
                    new Post
                    {
                        Title = "Announcing F# 5",
                        Content = "F# 5 is the latest version of F#, the functional programming language..."
                    },
                }
            });

        context.SaveChanges();
    }
}

#region OrderLine

public class OrderLine
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }

    //...
}

#endregion OrderLine

#region BlogDto

public class BlogDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

#endregion BlogDto

public class Blog : IEntityWithKey
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IList<Post> Posts { get; } = new List<Post>();
}

public class Post : IEntityWithKey
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int? BlogId { get; set; }
    public Blog Blog { get; set; }
}

#region IEntityWithKey

public interface IEntityWithKey
{
    int Id { get; set; }
}

#endregion IEntityWithKey

public class BlogsContext : DbContext
{
    private readonly bool _quiet;

    public BlogsContext(bool quiet = false)
    {
        _quiet = quiet;
    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }

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

    #region OnModelCreating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<OrderLine>()
            .HasKey(e => new { e.OrderId, e.ProductId });
    }

    #endregion OnModelCreating
}