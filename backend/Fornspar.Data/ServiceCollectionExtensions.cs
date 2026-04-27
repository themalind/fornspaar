using Fornspar.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fornspar.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFornsparData(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Fornspar") ?? throw new InvalidOperationException("Connection string 'Fornspar' not found.");

        services.AddDbContextFactory<Db.FornsparDbContext>(options =>
            options.UseNpgsql(connectionString, x =>
            {
                x.UseNetTopologySuite();
            }));

        services.AddTransient<IDbMigrationRunner, DbMigrationRunner>();

        return services;
    }
}