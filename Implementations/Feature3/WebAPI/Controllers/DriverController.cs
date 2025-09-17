using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("api")]
public class DriverController : ControllerBase
{
    private readonly ILocationService _locationService;

    public DriverController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("order/{orderId}/location/stream")]
    public async Task GetDriverLocationStream(int orderId)
    {
        try
        {
            while (!HttpContext.RequestAborted.IsCancellationRequested)
            {
                var location = _locationService.GetLocationByOrderId(orderId);
                if (location is not null)
                {
                    var json = JsonConvert.SerializeObject(location);
                    await Response.WriteAsync($"data: {json}\n\n");
                    await Response.Body.FlushAsync();
                }

                await Task.Delay(10000, HttpContext.RequestAborted);
            }
        }
        catch (Exception c)
        {
        }
    }

    [HttpPost("driver/location")]
    public IActionResult UpdateLocation([FromBody] DriverLocation location)
    {
        _locationService.UpdateDriverLocation(location);
        return Ok();
    }
}