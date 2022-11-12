using InBoxOutBoxExample.Application.Abstractions.MessageBroker;
using InBoxOutBoxExample.Domain.Write.Entities.Outbox;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace InBoxOutBoxExample.Persistence.Services
{
    public class MessageService : IMessageService
    {
        private readonly IConnection _connection;

        public MessageService(IConnection connection)
        {
            _connection = connection;
        }

        public void SendMessage(Outbox message, string queue, string routingKey, string exchange)
        {
            using (var channel = _connection.CreateModel())
            {
                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
                channel.BasicPublish(exchange, routingKey, null, body);
            }
        }
    }
}
