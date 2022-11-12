using InBoxOutBoxExample.Application.Abstractions.Services.Write;
using MediatR;

namespace InBoxOutBoxExample.Application.Features.Commands.ProductCommands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IProductWriteService _productService;

    public CreateProductCommandHandler(IProductWriteService productService)
    {
        _productService = productService;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        return await _productService.AddProduct(request);
    }
}
