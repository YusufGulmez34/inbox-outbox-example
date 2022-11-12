using InBoxOutBoxExample.Application.DTOs;

namespace InBoxOutBoxExample.Application.Features.Queries.ProductQuerries.GetAllProduct;

public class GetAllProductQueryResponse
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public List<ProductDTO>? Products { get; set; }

    public GetAllProductQueryResponse(string message, bool success, List<ProductDTO>? products)
    {
        Message = message;
        Success = success;
        Products = products;
    }    
}
