using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFQuerying.DataAcquisition;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new LazyLoad())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.SaveChanges();
        }

        using (var context = new LazyLoad())
        {
            var blog = new Blog { Name = "Test" };
            blog.Posts.Add(new Post { Title = "Title", Content = "Content" });
            context.Blogs.Add(blog);
            context.SaveChanges();
        }

        using (var context = new LazyLoad())
        {
            Console.WriteLine(context.Blogs.ToQueryString());
            var blog = context.Blogs.ToList();
            var posts = blog[0].Posts;
        }
    }
}