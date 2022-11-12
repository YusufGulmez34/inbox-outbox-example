using InBoxOutBoxExample.Application.Abstractions.Services.Write;
using MediatR;

namespace InBoxOutBoxExample.Application.Features.Commands.ProductCommands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IProductWriteService _productService;

    public UpdateProductCommandHandler(IProductWriteService productService)
    {
        _productService = productService;
    }

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        return await _productService.UpdateProduct(request);
    }
}
