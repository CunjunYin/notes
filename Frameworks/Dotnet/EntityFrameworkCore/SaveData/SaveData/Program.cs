namespace SaveData;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new CascadeDelete())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.SaveChanges();
        }

        using (var context = new CascadeDelete())
        {
            for (var i = 0; i < 5; i++)
            {
                var blog = new Blog { Name = $"Blog-{i}" };
                var post = new Post { Title = $"Post-{i}", Content = $"Content-{i}" };
                var author = new Author { Name = $"Author-{i}" };

                blog.Posts.Add(post);
                author.Posts.Add(post);
                blog.author = author;

                context.Blogs.Add(blog);
                context.Authors.Add(author);
            }
            context.SaveChanges();
        }

        try
        {
            using (var context = new CascadeDelete())
            {
                var authors = context.Authors.ToList();
                var posts = context.Posts.ToList();

                foreach (var blog in context.Blogs)
                {
                    context.Blogs.Remove(blog);
                }
                context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}