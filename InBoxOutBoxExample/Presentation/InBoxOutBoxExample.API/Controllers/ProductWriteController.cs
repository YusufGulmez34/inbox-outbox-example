using Microsoft.AspNetCore.Mvc;
using MediatR;
using InBoxOutBoxExample.Application.Features.Commands.ProductCommands.CreateProduct;
using InBoxOutBoxExample.Application.Features.Commands.ProductCommands.DeleteProduct;
using InBoxOutBoxExample.Application.Features.Commands.ProductCommands.UpdateProduct;

namespace InBoxOutBoxExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWriteController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductWriteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await _mediator.Send(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommandRequest request)
        {
            DeleteProductCommandResponse response = await _mediator.Send(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await _mediator.Send(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
