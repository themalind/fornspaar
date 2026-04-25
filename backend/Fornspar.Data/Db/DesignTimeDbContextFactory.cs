using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Fornspar.Data.Db;

public class FornsparDbContextFactory : IDesignTimeDbContextFactory<FornsparDbContext>
{
    public FornsparDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<FornsparDbContext>()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<FornsparDbContext>();
        optionsBuilder.UseNpgsql(config.GetConnectionString("Fornspar"));

        return new FornsparDbContext(optionsBuilder.Options);
    }
}