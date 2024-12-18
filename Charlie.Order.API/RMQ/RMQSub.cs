using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;

namespace Charlie.Order.API.RMQ;

public class RMQSub
{
    //private readonly ILogger<RMQSub> _logger;
    //private readonly IServiceProvider _serviceProvider;
    //private IConnection _connection;
    //private IModel _channel;

    //public RMQSub(ILogger<RMQSub> logger, IServiceProvider serviceProvider)
    //{
    //    _logger = logger;
    //    _serviceProvider = serviceProvider;
    //    InitializeRabbitMQ();
    //}

    //private void InitializeRabbitMQ()
    //{
    //    var factory = new ConnectionFactory { HostName = "localhost" };

    //    // Create connection and channel
    //    _connection = factory.CreateConnection();
    //    _channel = _connection.CreateModel();

    //    // Declare the queue
    //    _channel.QueueDeclare(
    //        queue: "order_queue",
    //        durable: true,
    //        exclusive: false,
    //        autoDelete: false,
    //        arguments: null);
    //}

    //protected override Task ExecuteAsync(CancellationToken stoppingToken)
    //{
    //    var consumer = new AsyncEventingBasicConsumer(_channel);
    //    consumer.Received += async (model, ea) =>
    //    {
    //        var body = ea.Body.ToArray();
    //        var message = Encoding.UTF8.GetString(body);

    //        _logger.LogInformation($"Received message: {message}");

    //        // Process the message
    //        using var scope = _serviceProvider.CreateScope();
    //        var orderService = scope.ServiceProvider.GetRequiredService<IOrderRMQService>();

    //        try
    //        {
    //            var orderRequest = JsonConvert.DeserializeObject<OrderRequestDTO>(message);
    //            if (orderRequest != null)
    //            {
    //                await orderService.CreateOrderAsync(orderRequest);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "Failed to process message");
    //        }
    //    };

    //    _channel.BasicConsume(
    //        queue: "order_queue",
    //        autoAck: true,
    //        consumer: consumer);

    //    return Task.CompletedTask; // Keeps the background service running
    //}

    //public override void Dispose()
    //{
    //    _channel?.Close();
    //    _connection?.Close();
    //    base.Dispose();
    //}
}
