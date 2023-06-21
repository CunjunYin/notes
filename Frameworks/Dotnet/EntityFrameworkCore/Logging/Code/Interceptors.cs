using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Microsoft.Extensions.Logging;

namespace Code;

public class Interceptors : DBContext
{
    private static readonly QueryTagInterceptor _interceptor = new QueryTagInterceptor("CUSTOM_TAG");
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("server=LAPTOP-F2QSIV4N;database=Logging;Integrated Security=True;trusted_connection=true;TrustServerCertificate=Yes");
        builder.AddInterceptors(_interceptor);

        builder.LogTo(
            Console.WriteLine,
            (eventId, logLevel) => logLevel >= LogLevel.Information
                || eventId == RelationalEventId.ConnectionOpened
                || eventId == RelationalEventId.ConnectionClosed,
            DbContextLoggerOptions.UtcTime | DbContextLoggerOptions.SingleLine
        );
        // builder.LogTo(_logStream.WriteLine);
        builder.EnableSensitiveDataLogging(); // Sensitive data logging
        builder.EnableDetailedErrors(); // Sacrifice performance for detail
    }
}

public class CustomCommandInterceptor : DbCommandInterceptor
{
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

    private static void ManipulateCommand(DbCommand command)
    {
        // Modify or inspect the command
        command.CommandText += " -- Custom modification";
        // Custom logic before command creation
    }

    // Implement other methods of IDbCommandInterceptor as needed
}

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