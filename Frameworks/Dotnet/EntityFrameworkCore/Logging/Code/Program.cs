using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace Code;
internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new Interceptors())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var post = new Post() { Title = "Post", Content = "Content" };
            var blog = new Blog() { Name = "Blog" };
            var author = new Author() { Name = "Author" };

            blog.Posts.Add(post);
            author.Posts.Add(post);
            blog.author = author;

            context.Blogs.Add(blog);
            context.Authors.Add(author);
            context.SaveChanges();
        }

        using (var context = new Interceptors())
        {
            var entity = context.Blogs.Where(e => e.Id == 1).Single();
            entity.Name = "EF Core Blog";
            context.SaveChanges();
        }
    }
}
