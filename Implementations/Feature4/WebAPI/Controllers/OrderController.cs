using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private static HttpResponse? RestaurantConnection;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> PostOrder([FromBody] Order order)
    {
        order.CreatedAt = DateTime.Now;

        _orderService.AddOrder(order);

        if (RestaurantConnection is not null)
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(order);
                await RestaurantConnection.WriteAsync($"data: {json}\n\n");
                await RestaurantConnection.Body.FlushAsync();
            }
            catch
            {
                RestaurantConnection = null;
            }
        }

        return Ok(new { order.OrderId });
    }

    [HttpGet("stream")]
    public async Task GetOrderStream()
    {
        RestaurantConnection = Response;

        try
        {
            while (!HttpContext.RequestAborted.IsCancellationRequested)
            {
                await Task.Delay(1000);
            }
        }
        finally
        {
            RestaurantConnection = null;
        }
    }
}

