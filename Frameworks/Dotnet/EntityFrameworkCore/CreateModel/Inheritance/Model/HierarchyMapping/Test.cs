using Microsoft.EntityFrameworkCore;

namespace Inheritance.Model.HierarchyMapping;

internal class Test
{
    public void Execute()
    {
        CleanDatabase();
        InitDatabase();

        using (var context = new HierarchyMapping())
        {
            Console.WriteLine(context.Blogs.ToQueryString());
            foreach (var blog in context.Blogs)
            {
                Console.WriteLine($"{blog.Url}");
            }

            Console.WriteLine();
            Console.WriteLine(context.RssBlogs.ToQueryString());
            foreach (var rssBlog in context.RssBlogs)
            {
                Console.WriteLine($"{rssBlog.Url}, {rssBlog.RssUrl}");
            }
        }
    }

    public static void InitDatabase()
    {
        using (var context = new HierarchyMapping())
        {
            var blog = new Blog() { Url = "www.blog.com" };
            var rssblog = new RssBlog() { Url = "www.blog.com", RssUrl = "www.rssblog.com" };

            context.Blogs.Add(blog);
            context.RssBlogs.Add(rssblog);

            context.SaveChanges();
        }
    }

    public static void CleanDatabase()
    {
        using (var context = new HierarchyMapping())
        {
            var qs = context.Blogs.ToQueryString();
            foreach (var blog in context.Blogs)
            {
                context.Blogs.Remove(blog);
            }

            foreach (var rssBlog in context.RssBlogs)
            {
                context.RssBlogs.Remove(rssBlog);
            }

            context.SaveChanges();
        }
    }
}