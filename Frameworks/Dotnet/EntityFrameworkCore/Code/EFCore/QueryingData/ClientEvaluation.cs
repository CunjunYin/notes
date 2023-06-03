
using EFCore.Extenions;
using EFCore.Models;

namespace EFCore.QueryingData;

public class ClientEvaluation
{
    private readonly DBContext Context;
    public ClientEvaluation(DBContext context)
    {
        this.Context = context;
    }

    public void Explicit()
    {

    }

    public static string Process(string name)
    {
        return name.ToLower().Capitalize();
    }
}