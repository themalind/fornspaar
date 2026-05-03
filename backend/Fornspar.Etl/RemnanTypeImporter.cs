using Microsoft.Extensions.Logging;

namespace Fornspar.Etl;

public class RemnanTypeImporter
{
    private readonly IDbContextFactory<FornsparDbContext> dbContextFactory;
    private readonly ILogger logger;

    public RemnanTypeImporter(
        IDbContextFactory<FornsparDbContext> dbContextFactory,
        ILogger<RemnanTypeImporter> logger)
    {
        this.dbContextFactory = dbContextFactory;
        this.logger = logger;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Starting import of remnant types.");

        string constr = @"Data Source=/home/shozan/Downloads/lämningar_sverige.gpkg;Mode=ReadOnly;Cache=Shared";

        using var con = new SqliteConnection(constr);
        await con.OpenAsync(cancellationToken);

        var command = new CommandDefinition("select distinct lamningstyp from lamning;", cancellationToken: cancellationToken);
        var remnantTypeAsStrings = await con.QueryAsync<string>(command);

        using var dbContext = await this.dbContextFactory.CreateDbContextAsync(cancellationToken);

        await dbContext.AddRangeAsync(remnantTypeAsStrings.Select(remnantTypeAsString => new RemnantType
        {
            Identifier = remnantTypeAsString
        }), cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        this.logger.LogInformation("Finished import of remnant types.");
    }
}