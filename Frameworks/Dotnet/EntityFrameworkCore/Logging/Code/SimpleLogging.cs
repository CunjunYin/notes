using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Code;

public class SimpleLogging : DBContext
{
    private readonly StreamWriter _logStream = new StreamWriter("mylog.txt", append: true);
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("server=LAPTOP-F2QSIV4N;database=Logging;Integrated Security=True;trusted_connection=true;TrustServerCertificate=Yes");
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

        // builder.LogTo(Console.WriteLine, LogLevel.Information);
        
    }

    public override void Dispose()
    {
        base.Dispose();
        _logStream.Dispose();
    }

    public override async ValueTask DisposeAsync()
    {
        await base.DisposeAsync();
        await _logStream.DisposeAsync();
    }
}