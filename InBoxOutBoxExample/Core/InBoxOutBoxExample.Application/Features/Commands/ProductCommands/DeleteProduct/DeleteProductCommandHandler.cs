using InBoxOutBoxExample.Application.Abstractions.Services.Write;
using MediatR;

namespace InBoxOutBoxExample.Application.Features.Commands.ProductCommands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    private IProductWriteService _productService;

    public DeleteProductCommandHandler(IProductWriteService productService)
    {
        _productService = productService;
    }

    public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        return await _productService.DeleteProduct(request);
    }
}
