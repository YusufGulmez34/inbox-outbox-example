using InBoxOutBoxExample.Application.Abstractions.Services.Read;
using MediatR;

namespace InBoxOutBoxExample.Application.Features.Queries.ProductQuerries.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
{
    private readonly IProductReadService _productService;

    public GetAllProductQueryHandler(IProductReadService productService)
    {
        _productService = productService;
    }

    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        return  await _productService.GetAllProduct(request); 
    }
}
