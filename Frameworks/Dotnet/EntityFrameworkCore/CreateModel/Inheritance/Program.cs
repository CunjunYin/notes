using Inheritance.Model;
using Microsoft.EntityFrameworkCore;
using Inheritance.Model.TablePerType;

namespace Relationship;

public class Program
{
    public static void Main(string[] args)
    {
        var test = new Test();
        test.Execute();
    }
}