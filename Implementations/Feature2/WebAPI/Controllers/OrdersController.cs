using Application;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{orderId}/status")]
    public IActionResult GetOrderStatus(int orderId)
    {
        var status = _orderService.GetOrderStatus(orderId);
        if (status is not null)
        {
            return Ok(new { OrderId = orderId, Status = status });
        }

        return NotFound(new { Message = "Order not found" });
    }
}
