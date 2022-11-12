using MediatR;

namespace InBoxOutBoxExample.Application.Features.Commands.ProductCommands.CreateProduct;

public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
}
