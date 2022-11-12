namespace InBoxOutBoxExample.Application.Features.Commands.ProductCommands.DeleteProduct;

public class DeleteProductCommandResponse
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public DeleteProductCommandResponse(string Message, bool Success)
    {
        this.Message = Message;
        this.Success = Success;
    }
}
