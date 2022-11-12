using InBoxOutBoxExample.Application.Features.Commands.ProductCommands.CreateProduct;
using InBoxOutBoxExample.Application.Features.Commands.ProductCommands.DeleteProduct;
using InBoxOutBoxExample.Application.Features.Commands.ProductCommands.UpdateProduct;

namespace InBoxOutBoxExample.Application.Abstractions.Services.Write
{
    public interface IProductWriteService
    {
        Task<CreateProductCommandResponse> AddProduct(CreateProductCommandRequest createProduct);
        Task<DeleteProductCommandResponse> DeleteProduct(DeleteProductCommandRequest deleteProduct);
        Task<UpdateProductCommandResponse> UpdateProduct(UpdateProductCommandRequest deleteProduct);

    }
}

