using InBoxOutBoxExample.Application.Abstractions.MessageBroker;
using InBoxOutBoxExample.Application.Abstractions.Repositories.Write;
using InBoxOutBoxExample.Domain.Write.Entities.Outbox;
using InBoxOutBoxExample.Domain.Write.Entities;
using InBoxOutBoxExample.Persistence.Contexts;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using InBoxOutBoxExample.Domain;

namespace InBoxOutBoxExample.Persistence.Repositories.Write
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        private readonly IMessageService _messageService;
        public ProductWriteRepository(InBoxOutBoxExampleWriteDbContext context, IMessageService messageService) : base(context)
        {
            _messageService = messageService;
        }

        public override async Task<int> SaveAndPublish<TEntity>(TEntity entity, string type, string queue, string routingKey, string exchange)
        {
            
            // await Context.SaveChangesAsync();
            if (type == "ProductCreated" || type == "ProductUpdated")
                await Context.SaveChangesAsync();
            
            
            var message = new ProductOutbox()
            {
                Guid = Guid.NewGuid(),
                Payload = JsonSerializer.Serialize(entity),
                Type = type
            };

            var outboxEntry = Context.Add(message);

            try
            {
                _messageService.SendMessage(message, queue, routingKey, exchange);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                
                return await Context.SaveChangesAsync();
            } 

            finally {}
            

            outboxEntry.Entity.ProcessDate = DateTime.UtcNow;
            return await Context.SaveChangesAsync();

        }
    }
}
