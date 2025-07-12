using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Cli.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Manual logging registration if AddLogging() isn't available
services.AddSingleton<ILoggerFactory, LoggerFactory>();
services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
services.AddSingleton<ILoggerProvider, ConsoleLoggerProvider>();

services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Information);
});

using var registrar = new DependencyInjectionRegistrar(services);
var app = new CommandApp(registrar);

app.Configure(config =>
{
    // configure your commands
});

return await app.RunAsync(args);
