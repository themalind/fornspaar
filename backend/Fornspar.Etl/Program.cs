using Fornspar.Data;
using Microsoft.Extensions.Logging;

namespace Fornspar.Etl;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(configurationBuilder =>
            {
                configurationBuilder.AddUserSecrets<Program>();
            })
            .ConfigureLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
            })
            .ConfigureServices((hostBuilderContext, services) =>
            {
                services.AddFornsparData(hostBuilderContext.Configuration);

                services.AddTransient<RemnanTypeImporter>();
                services.AddTransient<RemnantImporter>();
                services.AddTransient<RemnantPlacementImporter>();
            })
            .Build();

        using IServiceScope scope = host.Services.CreateScope();
        var applicationStoppingToken = scope.ServiceProvider.GetRequiredService<IHostApplicationLifetime>().ApplicationStopping;

        // var remnanTypeImporter = scope.ServiceProvider.GetRequiredService<RemnanTypeImporter>();
        // await remnanTypeImporter.ExecuteAsync(applicationStoppingToken);

        // var remnantPlacementImporter = scope.ServiceProvider.GetRequiredService<RemnantPlacementImporter>();
        // await remnantPlacementImporter.ExecuteAsync(applicationStoppingToken);
    }
}