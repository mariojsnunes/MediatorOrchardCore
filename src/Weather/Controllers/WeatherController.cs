using System.Threading.Tasks;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Weather.Requests;

[ApiController]
[Route("api/weather")]
public class WeatherApiController(IMediator mediator) : Controller
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult> Get()
    {
        var result = await mediator.Send(new GetWeather());

        return Ok(result);
    }
}
