using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Utilities;

namespace Fornspar.Etl;

public class RemnantImporter
{
    private readonly IDbContextFactory<FornsparDbContext> dbContextFactory;
    private readonly ILogger logger;

    public RemnantImporter(
        IDbContextFactory<FornsparDbContext> dbContextFactory,
        ILogger<RemnantImporter> logger)
    {
        this.dbContextFactory = dbContextFactory;
        this.logger = logger;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Starting import of remnants.");

        string constr = @"Data Source=/home/shozan/Downloads/lämningar_sverige.gpkg;Mode=ReadOnly;Cache=Shared";

        using var con = new SqliteConnection(constr);
        await con.OpenAsync(cancellationToken);

        var command = new CommandDefinition("""
        select 
            lamningsnummer,
            beskrivning,
            terrang,
            orientering,
            lamningstyp,
            placering
        from lamning;
        """, cancellationToken: cancellationToken);
        var remnants = await con.QueryAsync(command);


        using var dbContext = await this.dbContextFactory.CreateDbContextAsync(cancellationToken);

        foreach (var remnant in remnants)
        {
            string remnantTypeIdentifier = remnant.lamningstyp;
            var remnantType = await dbContext.RemnantTypes
                .FirstAsync(rt => rt.Identifier == remnantTypeIdentifier, cancellationToken);

            string? remnantPlacementIdentifier = remnant.placering;
            var remnantPlacement = await dbContext.RemnantPlacements
                .FirstOrDefaultAsync(rp => rp.Identifier == remnantPlacementIdentifier, cancellationToken);

            Console.WriteLine(remnant.geometries);

            

            var entity = new Remnant
            {
                Identifier = remnant.lamningsnummer,
                Description = remnant.beskrivning,
                Terrain = remnant.terrang,
                Orientation = remnant.orientering,
                RemnantType = remnantType,
                RemnantPlacement = remnantPlacement,
                Geometries = GeometryCollection.Empty
            };

            dbContext.Remnants.Add(entity);
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        this.logger.LogInformation("Finished import of remnants.");
    }
}
