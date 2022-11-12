using AutoMapper;
using InBoxOutBoxExample.Application.Abstractions.Repositories.Write;
using InBoxOutBoxExample.Application.Abstractions.Services.Write;
using InBoxOutBoxExample.Application.Features.Commands.ProductCommands.CreateProduct;
using InBoxOutBoxExample.Application.Features.Commands.ProductCommands.DeleteProduct;
using InBoxOutBoxExample.Application.Features.Commands.ProductCommands.UpdateProduct;
using InBoxOutBoxExample.Domain.Write.Entities;

namespace InBoxOutBoxExample.Persistence.Services.Write;

public class ProductWriteService : IProductWriteService
{
    private readonly IMapper _mapper;
    private readonly IProductWriteRepository _productRepository;

    public ProductWriteService(IMapper mapper, IProductWriteRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<CreateProductCommandResponse> AddProduct(CreateProductCommandRequest createProduct)
    {
        var ProductEntity = _mapper.Map<Product>(createProduct);
        if (!(await _productRepository.AddAsync(ProductEntity)))
            return new CreateProductCommandResponse("Error", false);

        await _productRepository.SaveAndPublish(ProductEntity, "ProductCreated", "product.event.productCreated", "productCreated", "product.events");
        return new CreateProductCommandResponse("Success", true);
    }

    public async Task<DeleteProductCommandResponse> DeleteProduct(DeleteProductCommandRequest deleteProduct)
    {
        if (!(await _productRepository.DeleteByIdAsync(deleteProduct.Id)))
            return new DeleteProductCommandResponse("Error", false);

        await _productRepository.SaveAndPublish(new Product(){Id=deleteProduct.Id}, "ProductDeleted", "product.event.productDeleted", "productDeleted", "product.events");
        return new DeleteProductCommandResponse("Success", true);
    }

    public async Task<UpdateProductCommandResponse> UpdateProduct(UpdateProductCommandRequest deleteProduct)
    {
        Product product = await _productRepository.FindById(deleteProduct.Id);

        if (product == null) return new UpdateProductCommandResponse("Error", false);

        product = _mapper.Map(deleteProduct, product);

        bool result = _productRepository.Update(product);

        if(!result) return new UpdateProductCommandResponse("Error", false);

        await _productRepository.SaveAndPublish(product, "ProductUpdated", "product.event.productUpdated", "productUpdated", "product.events");
        
        return new UpdateProductCommandResponse("Success", true);
    }
}
