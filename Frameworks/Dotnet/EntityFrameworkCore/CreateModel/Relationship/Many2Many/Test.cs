using Microsoft.EntityFrameworkCore;
using Relationship.Many2Many.Required;

namespace Relationship.Many2Many;

public class Test
{
    public Test()
    { }

    public void Execute()
    {
        CleanDatabase();
        InitDatabase();

        using (var context = new Many2ManyDBContext())
        {
            Console.WriteLine(context.Users.Include(a => a.books).ToQueryString());
            foreach (var user in context.Users.Include(a => a.books))
            {
                foreach (var book in user.books)
                {
                    Console.WriteLine($"{user.FullName} {book.BookName}");
                }
            }

        }
    }

    public static void InitDatabase()
    {
        using (var context = new Many2ManyDBContext())
        {
            var Usera = new User { FullName = "Jone Wick" };
            var Userb = new User { FullName = "Mike Wick" };

            var booka = new Book { BookName = "History" };
            var bookb = new Book { BookName = "Math" };

            Usera.books.Add(booka);
            Usera.books.Add(bookb);

            Userb.books.Add(booka);
            Userb.books.Add(bookb);

            context.Users.Add(Usera);
            context.Users.Add(Userb);

            context.SaveChanges();
        }
    }

    public static void CleanDatabase()
    {
        using (var context = new Many2ManyDBContext())
        {
            foreach (var author in context.Books)
            {
                context.Books.Remove(author);
            }

            foreach (var profile in context.Users)
            {
                context.Users.Remove(profile);
            }

            context.SaveChanges();
        }
    }
}