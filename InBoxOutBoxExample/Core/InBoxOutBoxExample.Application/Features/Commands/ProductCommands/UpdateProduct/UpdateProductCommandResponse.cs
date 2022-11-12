namespace InBoxOutBoxExample.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public UpdateProductCommandResponse(string Message, bool Success)
        {
            this.Message = Message;
            this.Success = Success;
        }
    }
}