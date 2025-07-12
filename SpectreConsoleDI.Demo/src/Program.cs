using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Spectre.Console.Cli;
using Spectre.Console.Cli.Extensions.DependencyInjection;

using SpectreConsoleDI.Demo.src.Helpers.Logging;

var services = new ServiceCollection();

// Register your custom ConsoleLogger as a singleton
services.AddScoped<ConsoleLogger>();

using var registrar = new DependencyInjectionRegistrar(services);

var app = new CommandApp(registrar);

app.Configure(config =>
{
    // Register your commands here
    config.AddCommand<ExampleCommand>("example");
});

return await app.RunAsync(args);

// Example command that uses the ConsoleLogger
public class ExampleCommand : Command
{
    private readonly ConsoleLogger _logger;

    public ExampleCommand(ConsoleLogger logger)
    {
        _logger = logger;
    }

    public override int Execute(CommandContext context)
    {
        _logger.LogInformation("Example command executed!");
        _logger.LogWarning("This is a warning message");
        _logger.LogError("This is an error message");
        
        return 0;
    }
}
