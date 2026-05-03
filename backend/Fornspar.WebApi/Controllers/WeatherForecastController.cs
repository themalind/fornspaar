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
                RemnantPlacement = "Plats 1"
            },
            new RemnantResponse
            {
                Identifier = "R2",
                Description = "Lämning 2",
                Terrain = "Öppen mark",
                Orientation = "Söder",
                RemnantType = "Typ B",
                RemnantPlacement = null
            }
        ];
    }
}
