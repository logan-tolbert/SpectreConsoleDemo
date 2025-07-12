using Microsoft.Extensions.Logging;
using Spectre.Console;

var logger = ConsoleLogger.CreateLogger();

AnsiConsole.Markup("[underline red]Hello[/] World!");
Console.WriteLine(Environment.NewLine);

logger.LogInformation("Your message here");

logger.LogWarning("Warning message");

logger.LogError("Error message");
