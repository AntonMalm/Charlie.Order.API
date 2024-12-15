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
        await _orderService.CreateOrderAsync(orderRequest);


        return Accepted();
    }
}

