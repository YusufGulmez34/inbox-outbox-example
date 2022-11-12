namespace InBoxOutBoxExample.Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public CreateProductCommandResponse(string Message, bool Success)
        {
            this.Message = Message;
            this.Success = Success;
        }
    }
}
