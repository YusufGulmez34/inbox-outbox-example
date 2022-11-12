using MediatR;

namespace InBoxOutBoxExample.Application.Features.Commands.ProductCommands.DeleteProduct;

public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
{
    public int Id { get; set; }
}
