using AutoMapper;
using InBoxOutBoxExample.Application.Abstractions.Repositories.Read;
using InBoxOutBoxExample.Application.Abstractions.Services.Read;
using InBoxOutBoxExample.Application.DTOs;
using InBoxOutBoxExample.Application.Features.Queries.ProductQuerries.GetAllProduct;
using InBoxOutBoxExample.Application.Features.Queries.ProductQuerries.GetProductById;
using InBoxOutBoxExample.Domain.Read.Entities;

namespace InBoxOutBoxExample.Persistence.Services.Read;

public class ProductReadService : IProductReadService
{
    private readonly IProductReadRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductReadService(IProductReadRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetAllProductQueryResponse> GetAllProduct(GetAllProductQueryRequest request)
    {
        List<Product> products = _productRepository.GetAll();
        if (products == null)
            return new GetAllProductQueryResponse("Error", false, null);
        
        List<ProductDTO> productsDTO = _mapper.Map<List<ProductDTO>>(products);
        return new GetAllProductQueryResponse("Success", true, productsDTO);
    }

    public async Task<GetProductByIdQueryResponse> GetProductById(GetProductByIdQueryRequest request)
    {
        Product product = _productRepository.GetById(request.Id);
        if (product == null)
            return new GetProductByIdQueryResponse("Error", false, null);
        
        ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
        return new GetProductByIdQueryResponse("Success", true, productDTO);

    }
}
