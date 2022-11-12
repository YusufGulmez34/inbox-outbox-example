using InBoxOutBoxExample.Application.DTOs;

namespace InBoxOutBoxExample.Application.Features.Queries.ProductQuerries.GetProductById;

public class GetProductByIdQueryResponse
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public ProductDTO Product { get; set; }
    public GetProductByIdQueryResponse(string message, bool success, ProductDTO product)
    {
        Message = message;
        Success = success;
        Product = product;
    }
}