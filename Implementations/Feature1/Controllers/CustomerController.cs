using Application.DTOs.CustomerModels;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/amenity")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var customerId = await _customerService.RegisterAsync(dto);
        return CreatedAtAction(nameof(Register), new { id = customerId }, new { Id = customerId });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var result = await _customerService.LoginAsync(dto);
        return Ok(result);
    }
}