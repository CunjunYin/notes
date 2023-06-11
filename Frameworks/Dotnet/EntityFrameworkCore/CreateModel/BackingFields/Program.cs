using BackingFields.Model;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BackingFields;

public class Program
{
    public static void Main(string[] args)
    {
        var test = new Test();
        test.Execute();
    }
}