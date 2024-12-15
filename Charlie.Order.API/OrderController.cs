using Charlie.Order.API.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Charlie.Order.API;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRMQService _orderService;

    public OrderController(IOrderRMQService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderRequestDTO orderRequest)
    {
        var result = await _orderService.CreateOrderAsync(orderRequest);

        //if (!result.Success)
        //{
        //    return StatusCode(500, result.Message); // Eller använd en annan statuskod
        //}

        return Accepted(new { Message = "Order processing started", CorrelationId = result.CorrelationId });
    }
}

