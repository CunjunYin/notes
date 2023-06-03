using EntityTypes.Model;
using Microsoft.EntityFrameworkCore;

namespace EntityTypes;

public class Program
{
    public static void Main(string[] args)
    {
        CleanDatabase();
        InitDatabase();
        TestStudenntView();
        TestStudenntFunction();
    }

    public static void InitDatabase()
    {
        using (var context = new DBContext())
        {
            context.Students.Add(new Student {
                Name = "Emmie Stark",
                Courses = 1,
            });

            context.Students.Add(new Student
            {
                Name = "Luther Cain",
                Courses = 3,
            });

            context.Students.Add(new Student
            {
                Name = "Zara Schultz",
                Courses = 4,
            });

            context.SaveChanges();
        }
    }

    public static void CleanDatabase()
    {
        using (var context = new DBContext())
        {
            foreach (var student in context.Students)
            {
                context.Students.Remove(student);
            }

            context.SaveChanges();
        }
    }

    public static void TestStudennt()
    {
        using (var context = new DBContext())
        {
            foreach (var student in context.Students)
            {
                Console.WriteLine($"{student.Name}, {student.Courses}");
            }
        }
    }

    public static void TestStudenntView()
    {
        using (var context = new DBContext())
        {
            var query = context.StudentsView;
            var qs = query.ToQueryString();
            foreach (var student in context.StudentsView)
            {
                Console.WriteLine($"{student.Name}, {student.NameLength}");
            }
        }
    }

    public static void TestStudenntFunction()
    {
        using (var context = new DBContext())
        {
            foreach (var student in context.StudentsFunction)
            {
                Console.WriteLine($"{student.Name}, {student.NameLength}");
            }
        }
    }
}