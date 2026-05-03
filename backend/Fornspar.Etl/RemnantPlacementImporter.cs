using System;

using Microsoft.Extensions.Logging;

namespace Fornspar.Etl;

public class RemnantPlacementImporter
{
    private readonly IDbContextFactory<FornsparDbContext> dbContextFactory;
    private readonly ILogger logger;

    public RemnantPlacementImporter(
        IDbContextFactory<FornsparDbContext> dbContextFactory,
        ILogger<RemnantPlacementImporter> logger)
    {
        this.dbContextFactory = dbContextFactory;
        this.logger = logger;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Starting import of remnant placements.");

        string constr = @"Data Source=/home/shozan/Downloads/lämningar_sverige.gpkg;Mode=ReadOnly;Cache=Shared";

        using var con = new SqliteConnection(constr);
        await con.OpenAsync(cancellationToken);

        var command = new CommandDefinition("select distinct placering from lamning;", cancellationToken: cancellationToken);
        var remnantPlacementAsStrings = await con.QueryAsync<string>(command);

        using var dbContext = await this.dbContextFactory.CreateDbContextAsync(cancellationToken);

        await dbContext.AddRangeAsync(remnantPlacementAsStrings.Select(remnantPlacementAsString => new RemnantPlacement
        {
            Identifier = remnantPlacementAsString
        }), cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        this.logger.LogInformation("Finished import of remnant placements.");
    }
}

