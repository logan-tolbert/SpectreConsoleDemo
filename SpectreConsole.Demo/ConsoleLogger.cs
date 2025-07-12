using Microsoft.Extensions.Logging;

internal class ConsoleLogger
{
    private static ILoggerFactory? _loggerFactory;

    // Create a logger factory and add console provider
    public static ILoggerFactory GetLoggerFactory()
    {
        if (_loggerFactory == null)
        {
            _loggerFactory = LoggerFactory.Create(builder =>
                builder.AddConsole());
        }
        return _loggerFactory;
    }

    // Create the logger
    public static ILogger<Program> CreateLogger()
    {
        return GetLoggerFactory().CreateLogger<Program>();
    }
}