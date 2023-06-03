using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace EFCore;

public class Program
{
    public static void Main(string[] args)
    {
        
    }
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return  Host
            .CreateDefaultBuilder(args)
            .UseConsoleLifetime(o => o.SuppressStatusMessages = true)
            .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false)
                        .AddCommandLine(args);
                }
            )
            .ConfigureServices((hostContext, services) => { })
            .ConfigureLogging((hostContext, logging) => { });
    }

}

