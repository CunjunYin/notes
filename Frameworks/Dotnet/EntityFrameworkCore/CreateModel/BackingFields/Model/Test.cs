namespace BackingFields.Model;

internal class Test
{
    public void Execute()
    {
        CleanDatabase();
        InitDatabase();

        using (var context = new DBContext())
        {
            foreach (var blog in context.Blogs)
            {
                Console.WriteLine(blog.Url);
            }

            foreach (var blog in context.FieldOnlyBlogs)
            {
                Console.WriteLine(blog.GetUrl());
            }
        }
    }

    public static void InitDatabase()
    {
        using (var context = new DBContext())
        {
            context.Blogs.Add(new Blog() { Url = "Https://google.com" });
            var fieldOnlyBlog = new FieldOnlyBlog();
            fieldOnlyBlog.SetUrl("Https://google.com");
            context.FieldOnlyBlogs.Add(fieldOnlyBlog);
            context.SaveChanges();
        }
    }

    public static void CleanDatabase()
    {
        using (var context = new DBContext())
        {
            foreach (var blog in context.Blogs)
            {
                context.Remove(blog);
            }

            foreach (var blog in context.FieldOnlyBlogs)
            {
                context.Remove(blog);
            }
            context.SaveChanges();
        }
    }
}