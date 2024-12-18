using System.Text.Json;
using Charlie.Order.API;
using Charlie.Order.API.Shared.DTOs;

namespace Charlie.Order.API
{
    public class OrderResponseListener : BackgroundService
    {
        private readonly RabbitMqClient _rabbitMqClient;
        private readonly ILogger<OrderResponseListener> _logger;

        public OrderResponseListener(RabbitMqClient rabbitMqClient, ILogger<OrderResponseListener> logger)
        {
            _rabbitMqClient = rabbitMqClient;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _rabbitMqClient.SubscribeAsync("order.responses", async message =>
            {
                try
                {
                    var response = JsonSerializer.Deserialize<OrderResponseDTO>(message);

                    if (response != null)
                    {
                        //_logger.LogInformation($"Recieved response for CorrelationId: {response.CorrelationId}, Status: {response.Status}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error processing message: {ex.Message}");
                }
            }, stoppingToken);
        }
    }
}