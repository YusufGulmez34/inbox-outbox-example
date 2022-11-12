using InBoxOutBoxExample.Application.Features.Queries.ProductQuerries.GetAllProduct;
using InBoxOutBoxExample.Application.Features.Queries.ProductQuerries.GetProductById;

namespace InBoxOutBoxExample.Application.Abstractions.Services.Read;

public interface IProductReadService
{
    Task<GetAllProductQueryResponse> GetAllProduct(GetAllProductQueryRequest request);
    Task<GetProductByIdQueryResponse> GetProductById(GetProductByIdQueryRequest request);

}
