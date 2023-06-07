using Relationship.Many2Many;
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