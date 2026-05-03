namespace Fornspar.WebApi.Contracts;

public class RemnantResponse
{
    public required string Identifier { get; init; }

    public required string Description { get; init; }

    public string? Terrain { get; init; }
    public string? Orientation { get; init; }

    public required string RemnantType { get; init; }
    public string? RemnantPlacement { get; init; }
}
