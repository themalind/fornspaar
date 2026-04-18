using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using NetTopologySuite.Geometries;

namespace Fornspar.Data.Db;

public class Remnant
{
    [Key]
    public int DbId { get; init; }

    /// <summary>
    /// lämningsnummer
    /// </summary>
    public required string Identifier { get; init; }

    public required string Description { get; init; }

    public string? Terrain { get; init; }
    public string? Orientation { get; init; }

    public required Geometry Geometry { get; init; }

    public required RemnantType RemnantType { get; init; }
    public RemnantPlacement? RemnantPlacement { get; init; }
}
