# Interceptor
In Entity Framework Core (EF Core), interceptors allow you to intercept and modify the behavior of the database operations performed by EF Core. Interceptors provide a way to execute custom code before or after executing queries, saving changes, or interacting with the database.

```c#
public class QueryTagInterceptor : DbCommandInterceptor
{
    private string _tag { get; set; }

    public QueryTagInterceptor(string tag)
    {
        _tag = tag;
    }

    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        ManipulateCommand(command);

        return result;
    }

    public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
    {
        ManipulateCommand(command);

        return new ValueTask<InterceptionResult<DbDataReader>>(result);
    }

    private void ManipulateCommand(DbCommand command)
    {
        if (!string.IsNullOrWhiteSpace(_tag))
        {
            command.CommandText = $"{command.CommandText} -- Tag: {_tag}";
        }
    }
}

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{   
    optionsBuilder
        .UseSqlServer("ConnectionString")
        .AddInterceptors(new QueryTagInterceptor("custom-tag"));
}
```