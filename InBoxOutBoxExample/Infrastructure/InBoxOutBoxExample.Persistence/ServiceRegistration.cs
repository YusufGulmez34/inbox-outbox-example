using InBoxOutBoxExample.Application.Abstractions.MessageBroker;
using InBoxOutBoxExample.Application.Abstractions.Repositories.Read;
using InBoxOutBoxExample.Application.Abstractions.Repositories.Write;
using InBoxOutBoxExample.Application.Abstractions.Services.Read;
using InBoxOutBoxExample.Application.Abstractions.Services.Write;
using InBoxOutBoxExample.Persistence.Contexts;
using InBoxOutBoxExample.Persistence.Repositories.Read;
using InBoxOutBoxExample.Persistence.Repositories.Write;
using InBoxOutBoxExample.Persistence.Services;
using InBoxOutBoxExample.Persistence.Services.Read;
using InBoxOutBoxExample.Persistence.Services.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace InBoxOutBoxExample.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<InBoxOutBoxExampleWriteDbContext>(options => options.UseNpgsql(Configuration.PostgreSQLConnectionString), ServiceLifetime.Singleton);
            services.AddSingleton<InBoxOutBoxExampleReadDbContext>(sp => new InBoxOutBoxExampleReadDbContext(Configuration.MongoDBConfig));
            services.AddSingleton<IConnection>(sp => Configuration.RabbitMqConfig.CreateConnection()).AddHealthChecks();
            services.AddSingleton<IMessageService, MessageService>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteService, ProductWriteService>();
            services.AddSingleton<IProductReadService, ProductReadService>();

        }
    }
}
