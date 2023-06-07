using Microsoft.EntityFrameworkCore;
using Relationship.One2Many.Required;

namespace Relationship.One2Many;

public class Test
{
    public Test()
    { }

    public void Execute()
    {
        CleanDatabase();
        InitDatabase();

        using (var context = new One2ManyDBContext())
        {
            Console.WriteLine(context.Authors.ToQueryString());
            foreach (var author in context.Authors.Include(a => a.Books))
            {
                Console.WriteLine($"{author.Name}, {author.Books.ToArray()}");
            }
        }
    }

    public static void InitDatabase()
    {
        using (var context = new One2ManyDBContext())
        {
            var author = new Author { Name = "Jone Wick" };
            var booka = new Book { BookName = "History" };
            var bookb = new Book { BookName = "Math" };

            author.Books.Add( booka );
            author.Books.Add( bookb );

            context.Authors.Add(author);
            //context.Books.Add(booka);
            //context.Books.Add(bookb);

            context.SaveChanges();
        }
    }

    public static void CleanDatabase()
    {
        using (var context = new One2ManyDBContext())
        {

            foreach (var profile in context.Books)
            {
                context.Books.Remove(profile);
            }

            foreach (var author in context.Authors)
            {
                context.Authors.Remove(author);
            }

            context.SaveChanges();
        }
    }
}