using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AutoMapper;
using InBoxOutBoxExample.Application.Mapping;

namespace InBoxOutBoxExample.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration));
            collection.AddAutoMapper(typeof(MappingProfile));
        }
    }

}

