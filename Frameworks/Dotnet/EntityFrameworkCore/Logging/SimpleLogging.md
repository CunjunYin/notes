# Simple Logging
## Enabling logging
EF core can configure logging to different locations based on the requirements. EF Core uses a logging provider model that allows you to choose from various logging providers and configure them accordingly.
```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.LogTo(Console.WriteLine); // Write to console
}
```

## Logging levels
EF Core can configure the logging level to control the amount of detail logged by the framework. The logging level determines which log messages are included based on their severity.
```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
}
```

## Filtering and formatting
```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder
        .LogTo(
            Console.WriteLine,
            (eventId, logLevel) => 
                logLevel >= LogLevel.Information // Level higher than information
                || eventId == RelationalEventId.ConnectionOpened // Log connect 
                || eventId == RelationalEventId.ConnectionClosed // Log disconnect
        );
}
```

### Logging providers
Entity Framework Core supports multiple logging providers that you can use to capture and analyze the generated log messages. Each logging provider offers various features and options for logging to different destinations and formats.

Common providers:
1. Console Logging Provider (Microsoft.Extensions.Logging.Console)
2. Debug Logging Provider (Microsoft.Extensions.Logging.Debug)
3. EventSource Logging Provider (Microsoft.Extensions.Logging.EventSource)
4. TraceSource Logging Provider (Microsoft.Extensions.Logging.TraceSource)
5. Serilog Logging Provider (Serilog.Extensions.Logging)
6. 
```csharp
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole(); // Add the console logger provider
    builder.AddDebug(); // Add the debug logger provider
});

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder
        .UseLoggerFactory(MyLoggerFactory)
        .UseSqlServer("ConnectionString");
}
```
