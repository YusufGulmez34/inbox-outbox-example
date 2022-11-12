using InBoxOutBoxExample.Domain.Write.Entities;
using InBoxOutBoxExample.Domain.Write.Entities.Outbox;

namespace InBoxOutBoxExample.Application.Abstractions.MessageBroker
{
    public interface IMessageService
    {
        void SendMessage(Outbox message, string queue,string routingKey, string exchange);
    }
}
