using Charlie.Order.API.Shared.DataModels;
using Charlie.Order.API.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Charlie.Order.API;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly RabbitMqClient _rabbitMqClient;

    public OrderController(RabbitMqClient rabbitMqClient)
    {
        _rabbitMqClient = rabbitMqClient;
    }

    [HttpGet("{ordermerId}")]
    public async Task<IActionResult> GetOrderByIdAsync(int orderId)
    {
        if (orderId == null)
        {
            return BadRequest("Customer Id is null");
        }

        var correlationId = Guid.NewGuid().ToString();
        var message = new
        {
            CorrelationId = correlationId,
            Operation = "Read",
            Payload = new { OrderId = orderId }
        };
        await _rabbitMqClient.PublishAsync("order.operations", message);
        return Accepted(new { Message = "Order retrieval started.", CorrelationId = correlationId });
    }


    [HttpPost]
    public async Task<IActionResult> AddCustomerAsync([FromBody] OrderModel order)
    {
        if (order == null)
        {
            return BadRequest("Customer is null");
        }

        var correlationId = Guid.NewGuid().ToString();

        var message = new
        {
            CorrelationId = correlationId,
            Operation = "Create",
            Payload = order
        };


        await _rabbitMqClient.PublishAsync("order.operations", message);
        return Accepted(new { Message = "Order creation started.", CorrelationId = correlationId });
    }
}

