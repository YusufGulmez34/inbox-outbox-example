using MediatR;

namespace InBoxOutBoxExample.Application.Features.Commands.ProductCommands.UpdateProduct;

public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
}
