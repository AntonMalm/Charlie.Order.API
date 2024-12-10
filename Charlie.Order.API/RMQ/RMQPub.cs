using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Charlie.Order.API.RMQ
{
    public class RMQPub : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RMQPub(string rabbitMQConnectionString)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(rabbitMQConnectionString)
            };

            // Create connection and channel
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public async Task PublishAsync(string queueName, string message)
        {
            try
            {
                // Ensure the queue exists
                _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                // Publish the message
                var body = Encoding.UTF8.GetBytes(message);
                _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);

                await Task.CompletedTask; // Simulate async operation
            }
            catch (BrokerUnreachableException ex)
            {
                // Handle connection errors
                Console.WriteLine($"Broker unreachable: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other errors
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}