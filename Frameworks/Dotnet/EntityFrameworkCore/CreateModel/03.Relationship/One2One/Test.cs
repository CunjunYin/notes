using Microsoft.EntityFrameworkCore;
using Relationship.One2One.Required;

namespace Relationship.One2One;

public class Test
{
    public Test()
    { }

    public void Execute()
    {
        CleanDatabase();
        InitDatabase();

        using (var context = new One2OneDBContext())
        {
            Console.WriteLine(context.Authors.Include(a => a.Profile).ToQueryString());
            foreach (var author in context.Authors.Include(a => a.Profile))
            {
                Console.WriteLine($"{author.Name}, {author.Profile.Age}");
            }

            Console.WriteLine();
            Console.WriteLine(context.Profiles.ToQueryString());
            foreach (var profile in context.Profiles)
            {
                Console.WriteLine($"{profile.Author.Name}, {profile.Age}");
            }
        }
    }

    public static void InitDatabase()
    {
        using (var context = new One2OneDBContext())
        {
            var author = new Author {
                Name = "Jone Wick",
                
            };
            var profile = new Profile
            {
                Age = 32,
            };

            author.Profile = profile;
            profile.Author = author;
            context.Authors.Add(author);
            context.Profiles.Add(profile);

            context.SaveChanges();
        }
    }

    public static void CleanDatabase()
    {
        using (var context = new One2OneDBContext())
        {
            foreach (var author in context.Authors)
            {
                context.Authors.Remove(author);
            }

            foreach (var profile in context.Profiles)
            {
                context.Profiles.Remove(profile);
            }

            context.SaveChanges();
        }
    }
}