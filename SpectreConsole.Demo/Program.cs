using Microsoft.Extensions.Logging;
using Spectre.Console;

// Create a logger factory and add console provider
using var loggerFactory = LoggerFactory.Create(builder =>
    builder.AddConsole());

// Create the logger
var logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("Application started\n");
Console.WriteLine(Environment.NewLine);

AnsiConsole.Markup("[underline red]Hello[/] World!");

Console.WriteLine(Environment.NewLine);
logger.LogInformation("Application finished");