using NetTopologySuite.Geometries;

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
        var remnants = (await con.QueryAsync(command))
            .Select(r => new
            {
                lamningsnummer = (string)r.lamningsnummer,
                beskrivning = (string)r.beskrivning,
                terrang = (string?)r.terrang,
                orientering = (string?)r.orientering,
                lamningstyp = (string)r.lamningstyp,
                placering = (string)r.placering
            })
            .ToList();

        (Dictionary<string, RemnantType> remnantTypes, Dictionary<string, RemnantPlacement> remnantPlacements, Dictionary<string, List<byte[]>> geometries) = await NewMethod(con, cancellationToken);

        var currentTotal = 0;
        foreach (var remnantChunk in remnants.Chunk(100))
        {
            using var dbContext = await this.dbContextFactory.CreateDbContextAsync(cancellationToken);

            foreach (var remnant in remnantChunk)
            {
                currentTotal += 1;

                var remnantTypeIdentifier = remnant.lamningstyp;
                if (!remnantTypes.TryGetValue(remnantTypeIdentifier, out var remnantType))
                {
                    this.logger.LogWarning("Remnant type with identifier {Identifier} not found. Skipping remnant with lamningsnummer {Lamningsnummer}.", remnantTypeIdentifier, remnant.lamningsnummer);
                    continue;
                }

                dbContext.Attach(remnantType);

                var remnantPlacementIdentifier = remnant.placering;
                if (remnantPlacements.TryGetValue(remnantPlacementIdentifier, out var remnantPlacement))
                {
                    dbContext.Attach(remnantPlacement);
                }

                var reader = new NetTopologySuite.IO.GeoPackageGeoReader();
                if (!geometries.TryGetValue(remnant.lamningsnummer, out var geometriesForRemnant))
                {
                    this.logger.LogWarning("Geometries for remnant with lamningsnummer {Lamningsnummer} not found. Skipping remnant.", remnant.lamningsnummer);
                    continue;
                }

                var geometryCollection = new GeometryCollection([.. geometriesForRemnant.Select(g => reader.Read(g))]);

                var entity = new Remnant
                {
                    Identifier = remnant.lamningsnummer,
                    Description = remnant.beskrivning,
                    Terrain = remnant.terrang,
                    Orientation = remnant.orientering,
                    RemnantType = remnantType,
                    RemnantPlacement = remnantPlacement,
                    Geometries = geometryCollection
                };

                dbContext.Remnants.Add(entity);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            this.logger.LogInformation("Imported {Count} remnants..", currentTotal);
        }

        this.logger.LogInformation("Finished import of remnants.");

        async Task<(Dictionary<string, RemnantType> remnantTypes, Dictionary<string, RemnantPlacement> remnantPlacements, Dictionary<string, List<byte[]>> geometries)> NewMethod(SqliteConnection con, CancellationToken cancellationToken)
        {
            using var dbContext = await this.dbContextFactory.CreateDbContextAsync(cancellationToken);

            var remnantTypes = await dbContext.RemnantTypes.ToDictionaryAsync(rt => rt.Identifier, cancellationToken);
            var remnantPlacements = await dbContext.RemnantPlacements.ToDictionaryAsync(rp => rp.Identifier, cancellationToken);

            var geoCommand = new CommandDefinition("""
        select 
            lamningsnummer,
            geometri
        from lämningar_sverige_linestring l 
        union 
        select 
            lamningsnummer,
            geometri
        from lämningar_sverige_polygon p 
        union 
        select
            lamningsnummer,
            geometri
        from lämningar_sverige_point pt 
        """, cancellationToken: cancellationToken);

            var geometries = (await con.QueryAsync(geoCommand))
                .GroupBy(g => (string)g.lamningsnummer)
                .ToDictionary(g => g.Key, g => g.Select(g => g.geometri).OfType<byte[]>().ToList());
            return (remnantTypes, remnantPlacements, geometries);
        }
    }
}
