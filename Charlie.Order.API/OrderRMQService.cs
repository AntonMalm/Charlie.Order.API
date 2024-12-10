using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Charlie.Order.API.RMQ;
using Charlie.Order.API.Shared.DTOs;
using Newtonsoft.Json;


namespace Charlie.Order.API;

public class OrderRMQService : IOrderRMQService
{
    private readonly RMQPub _rmqPub;
    private readonly RMQSub _rmqSub;
    public OrderRMQService(RMQPub rmqPub, RMQSub rmqSub)
    {
        _rmqPub = rmqPub;
        _rmqSub = rmqSub;
    }
    public Task<OrderResponseDTO> CreateOrderAsync(OrderRequestDTO orderRequest)
    {
        var message = JsonConvert.SerializeObject(orderRequest);

        // Assume _rabbitMQService is an instance of a RabbitMQ publishing service
        await _rabbitMQService.PublishAsync("order_queue", message);
    }
}