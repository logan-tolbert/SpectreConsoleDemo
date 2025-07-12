using Microsoft.Extensions.Logging;

internal static class ConsoleLogger
{
    private static ILoggerFactory? _loggerFactory;

    // Create a logger factory and add console provider
    public static ILoggerFactory GetLoggerFactory()
    {
        _loggerFactory ??= LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddConsole();
                // builder.AddJsonConsole();
            });
        return _loggerFactory;
    }

    // Create the logger
    public static ILogger<Program> CreateLogger()
    {
        return GetLoggerFactory().CreateLogger<Program>();
    }

    public static void LogDateTimeUTC(this ILogger logger)
    {
      logger.LogInformation(LogEvents.TimestampEventId, "Timestamp recorded: {Timestamp} UTC", DateTime.UtcNow);
    }
}