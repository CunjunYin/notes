using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFQuerying.DataAcquisition;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new DBContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.SaveChanges();
        }

        using (var context = new DBContext())
        {
            for (var i = 0; i < 100; i++)
            {
                var blog = new Blog { Name = $"Test-{i}" };
                blog.Posts.Add(new Post { Title = $"Title-{i}", Content = $"Content-{i}" });
                context.Blogs.Add(blog);
            }
            context.SaveChanges();
        }

        //Offset pagination
        using (var context = new DBContext())
        {
            var position = 20;
            var nextPage = context.Posts
                .OrderBy(b => b.Id)
                .Skip(position)
                .Take(10);

            Console.WriteLine(nextPage.ToQueryString());
        }

        //Keyset pagination
        using (var context = new DBContext())
        {
            var position = 20;
            var nextPage = context.Posts
                .OrderBy(b => b.Id)
                .Where(b => b.Id > position)
                .Take(10);

            Console.WriteLine(nextPage.ToQueryString());
        }
    }
}