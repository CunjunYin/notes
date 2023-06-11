using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFQuerying.DataAcquisition;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new BloggingContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        using (var context = new BloggingContext())
        {
            var blogs = context.Blogs
                .Include(blog => blog.Posts)
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var blogs = context.Blogs
                .Include(blog => blog.Posts)
                .Select(
                    blog => new { Id = blog.BlogId, blog.Url })
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var blogs = context.Blogs
                .Include(blog => blog.Posts)
                .Include(blog => blog.Owner)
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var blogs = context.Blogs
                .Include(blog => blog.Posts)
                .ThenInclude(post => post.Author)
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var blogs = context.Blogs
                .Include(blog => blog.Posts)
                .ThenInclude(post => post.Author)
                .ThenInclude(author => author.Photo)
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var blogs = context.Blogs
                .Include(blog => blog.Posts)
                .ThenInclude(post => post.Author)
                .ThenInclude(author => author.Photo)
                .Include(blog => blog.Owner)
                .ThenInclude(owner => owner.Photo)
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var blogs = context.Blogs
                .Include(blog => blog.Posts)
                .ThenInclude(post => post.Author)
                .Include(blog => blog.Posts)
                .ThenInclude(post => post.Tags)
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var blogs = context.Blogs
                .Include(blog => blog.Owner.AuthoredPosts)
                .ThenInclude(post => post.Blog.Owner.Photo)
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var blogs = context.Blogs
                .Include(blog => blog.Posts)
                .AsSplitQuery()
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var blog = context.Blogs
                .Single(b => b.BlogId == 1);

            context.Entry(blog)
                .Collection(b => b.Posts)
                .Load();

            context.Entry(blog)
                .Reference(b => b.Owner)
                .Load();
        }

        using (var context = new BloggingContext())
        {
            var blog = context.Blogs
                .Single(b => b.BlogId == 1);

            var postCount = context.Entry(blog)
                .Collection(b => b.Posts)
                .Query()
                .Count();
        }

        using (var context = new BloggingContext())
        {
            var blog = context.Blogs
                .Single(b => b.BlogId == 1);

            var goodPosts = context.Entry(blog)
                .Collection(b => b.Posts)
                .Query()
                .Where(p => p.Rating > 3)
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var filteredBlogs = context.Blogs
                .Include(
                    blog => blog.Posts
                        .Where(post => post.BlogId == 1)
                        .OrderByDescending(post => post.Title)
                        .Take(5))
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var filteredBlogs = context.Blogs
                .Include(blog => blog.Posts.Where(post => post.BlogId == 1))
                .ThenInclude(post => post.Author)
                .Include(blog => blog.Posts)
                .ThenInclude(post => post.Tags.OrderBy(postTag => postTag.TagId).Skip(3))
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var filteredBlogs = context.Blogs
                .Include(blog => blog.Posts.Where(post => post.BlogId == 1))
                .ThenInclude(post => post.Author)
                .Include(blog => blog.Posts.Where(post => post.BlogId == 1))
                .ThenInclude(post => post.Tags.OrderBy(postTag => postTag.TagId).Skip(3))
                .ToList();
        }

        using (var context = new BloggingContext())
        {
            var themes = context.Themes.ToList();
        }

        using (var context = new BloggingContext())
        {
            var themes = context.Themes.IgnoreAutoIncludes().ToList();
        }
    }
}