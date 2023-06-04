using Relationship.One2One;
using Microsoft.EntityFrameworkCore;

namespace Relationship;

public class Program
{
    public static void Main(string[] args)
    {
        var test = new Test();
        test.Execute();
    }
}