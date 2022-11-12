using MediatR;

namespace InBoxOutBoxExample.Application.Features.Queries.ProductQuerries.GetProductById;

public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
{
    public int Id { get; set; }
}
