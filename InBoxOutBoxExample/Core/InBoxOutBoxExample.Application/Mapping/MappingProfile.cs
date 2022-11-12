using AutoMapper;
using InBoxOutBoxExample.Application.DTOs;
using InBoxOutBoxExample.Application.Features.Commands.ProductCommands.CreateProduct;
using InBoxOutBoxExample.Application.Features.Commands.ProductCommands.UpdateProduct;
using Write = InBoxOutBoxExample.Domain.Write.Entities;
using Read = InBoxOutBoxExample.Domain.Read.Entities;

namespace InBoxOutBoxExample.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductCommandRequest, Write.Product>().ReverseMap();
        CreateMap<UpdateProductCommandRequest, Write.Product>().ReverseMap();
        CreateMap<ProductDTO, Read.Product>().ReverseMap();
    }
}