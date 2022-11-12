using InBoxOutBoxExample.Application.Abstractions.Services.Read;
using MediatR;

namespace InBoxOutBoxExample.Application.Features.Queries.ProductQuerries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
{
    private readonly IProductReadService _productService;

    public GetProductByIdQueryHandler(IProductReadService productService)
    {
        _productService = productService;
    }
    

    public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
    {
        return await _productService.GetProductById(request);
    }
}
