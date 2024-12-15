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
    public OrderRMQService(RMQPub rmqPub)
    {
        _rmqPub = rmqPub;
    }
    public async Task CreateOrderAsync(OrderRequestDTO orderRequest)
    {
        var message = JsonConvert.SerializeObject(orderRequest);

        // Assume _rabbitMQService is an instance of a RabbitMQ publishing service

        // Publicerar ett meddelande i payment.operations-kön
        await _rmqPub.PublishAsync("payment.operations", message);

        // Publicerar ett meddelande i order.operations-kön
        //await _rabbitMQService.PublishAsync("order_queue", message);
    }
}