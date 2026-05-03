using Fornspar.WebApi.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace Fornspar.WebApi.Controllers;

[ApiController]
[Route("remnant")]
public class RemnantController : ControllerBase
{
    [HttpGet]
    [Route("all")]
    public IEnumerable<RemnantResponse> GetAll()
    {
        return
        [
            new RemnantResponse
            {
                Identifier = "R1",
                Description = "Lämning 1",
                Terrain = "Skog",
                Orientation = "Norr",
                RemnantType = "Typ A",
                RemnantPlacement = "Plats 1",
                Latitude = 59.3293m,
                Longitude = 18.0686m
            },
            new RemnantResponse
            {
                Identifier = "R2",
                Description = "Lämning 2",
                Terrain = "Öppen mark",
                Orientation = "Söder",
                RemnantType = "Typ B",
                RemnantPlacement = null,
                Latitude = 59.8586m,
                Longitude = 17.6389m
            },
            new RemnantResponse
            {
                Identifier = "VG1",
                Description = "Hög vid Göteborg",
                Terrain = "Skog",
                Orientation = "Norr",
                RemnantType = "Hög",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 57.7089m,
                Longitude = 11.9746m
            },
            new RemnantResponse
            {
                Identifier = "VG2",
                Description = "Gravfält Kungälv",
                Terrain = "Öppen mark",
                Orientation = "Väst",
                RemnantType = "Gravfält",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 57.8713m,
                Longitude = 11.9764m
            },
            new RemnantResponse
            {
                Identifier = "VG3",
                Description = "Boplats Trollhättan",
                Terrain = "Åker",
                Orientation = "Söder",
                RemnantType = "Boplats",
                RemnantPlacement = "Ej synlig ovan mark",
                Latitude = 58.2836m,
                Longitude = 12.2886m
            },
            new RemnantResponse
            {
                Identifier = "VG4",
                Description = "Runsten Skara",
                Terrain = "Öppen mark",
                Orientation = "Öst",
                RemnantType = "Runsten",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 58.3861m,
                Longitude = 13.4373m
            },
            new RemnantResponse
            {
                Identifier = "VG5",
                Description = "Fornborg Lidköping",
                Terrain = "Skog",
                Orientation = "Norr",
                RemnantType = "Fornborg",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 58.5053m,
                Longitude = 13.1571m
            },
            new RemnantResponse
            {
                Identifier = "VG6",
                Description = "Stensättning Borås",
                Terrain = "Skog",
                Orientation = "Söder",
                RemnantType = "Stensättning",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 57.7210m,
                Longitude = 12.9400m
            },
            new RemnantResponse
            {
                Identifier = "VG7",
                Description = "Hällristning Tanum",
                Terrain = "Berg",
                Orientation = "Söder",
                RemnantType = "Hällristning",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 58.7228m,
                Longitude = 11.3289m
            },
            new RemnantResponse
            {
                Identifier = "VG8",
                Description = "Gravhög Falköping",
                Terrain = "Åker",
                Orientation = "Väst",
                RemnantType = "Hög",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 58.1731m,
                Longitude = 13.5517m
            },
            new RemnantResponse
            {
                Identifier = "VG9",
                Description = "Boplats Vänersborg",
                Terrain = "Öppen mark",
                Orientation = "Norr",
                RemnantType = "Boplats",
                RemnantPlacement = "Ej synlig ovan mark",
                Latitude = 58.3800m,
                Longitude = 12.3230m
            },
            new RemnantResponse
            {
                Identifier = "VG10",
                Description = "Domarring Alingsås",
                Terrain = "Skog",
                Orientation = "Öst",
                RemnantType = "Domarring",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 57.9296m,
                Longitude = 12.5333m
            },
            new RemnantResponse
            {
                Identifier = "VG11",
                Description = "Fornborg Strömstad",
                Terrain = "Berg",
                Orientation = "Väst",
                RemnantType = "Fornborg",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 58.9358m,
                Longitude = 11.1673m
            },
            new RemnantResponse
            {
                Identifier = "VG12",
                Description = "Hällristning Kville",
                Terrain = "Berg",
                Orientation = "Söder",
                RemnantType = "Hällristning",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 58.6500m,
                Longitude = 11.2800m
            },
            new RemnantResponse
            {
                Identifier = "VG13",
                Description = "Gravfält Tidaholm",
                Terrain = "Åker",
                Orientation = "Norr",
                RemnantType = "Gravfält",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 58.1769m,
                Longitude = 13.9550m
            },
            new RemnantResponse
            {
                Identifier = "VG14",
                Description = "Stensättning Lerum",
                Terrain = "Skog",
                Orientation = "Söder",
                RemnantType = "Stensättning",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 57.7694m,
                Longitude = 12.2692m
            },
            new RemnantResponse
            {
                Identifier = "VG15",
                Description = "Runsten Mariestad",
                Terrain = "Öppen mark",
                Orientation = "Öst",
                RemnantType = "Runsten",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 58.7085m,
                Longitude = 13.8247m
            },
            new RemnantResponse
            {
                Identifier = "VG16",
                Description = "Boplats Mölndal",
                Terrain = "Skog",
                Orientation = "Norr",
                RemnantType = "Boplats",
                RemnantPlacement = "Ej synlig ovan mark",
                Latitude = 57.6554m,
                Longitude = 12.0136m
            },
            new RemnantResponse
            {
                Identifier = "VG17",
                Description = "Domarring Herrljunga",
                Terrain = "Åker",
                Orientation = "Väst",
                RemnantType = "Domarring",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 58.0792m,
                Longitude = 13.0253m
            },
            new RemnantResponse
            {
                Identifier = "VG18",
                Description = "Hög Lysekil",
                Terrain = "Berg",
                Orientation = "Söder",
                RemnantType = "Hög",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 58.2750m,
                Longitude = 11.4358m
            },
            new RemnantResponse
            {
                Identifier = "VG19",
                Description = "Gravfält Skövde",
                Terrain = "Öppen mark",
                Orientation = "Norr",
                RemnantType = "Gravfält",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 58.3910m,
                Longitude = 13.8460m
            },
            new RemnantResponse
            {
                Identifier = "VG20",
                Description = "Fornborg Uddevalla",
                Terrain = "Berg",
                Orientation = "Väst",
                RemnantType = "Fornborg",
                RemnantPlacement = "Synlig ovan mark",
                Latitude = 58.3488m,
                Longitude = 11.9384m
            }
        ];
    }
}
