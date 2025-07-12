using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SpectreConsoleDI.Demo.src.Helpers.Logging;

public class ConsoleLogger
{
    private readonly ILogger _logger;

    public ConsoleLogger()
    {
        using IHost host = Host.CreateDefaultBuilder()
            .ConfigureLogging(h =>
            {
                h.AddJsonConsole();
            })
            .Build();
        
        _logger = host.Services.GetRequiredService<ILoggerFactory>().CreateLogger<ConsoleLogger>();
    }

    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
    }

    public void LogWarning(string message, params object[] args)
    {
        _logger.LogWarning(message, args);
    }

    public void LogError(string message, params object[] args)
    {
        _logger.LogError(message, args);
    }

    public void LogError(Exception exception, string message, params object[] args)
    {
        _logger.LogError(exception, message, args);
    }
}
