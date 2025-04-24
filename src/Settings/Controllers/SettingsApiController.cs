using System.Threading.Tasks;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Settings.Requests;

[ApiController]
[Route("api/settings")]
public class SettingsApiController(IMediator mediator) : Controller
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult> Get()
    {
        var result = await mediator.Send(new GetSettings());

        return Ok(result);
    }
}
