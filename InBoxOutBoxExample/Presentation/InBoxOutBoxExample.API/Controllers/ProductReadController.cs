using InBoxOutBoxExample.Application.Features.Queries.ProductQuerries.GetAllProduct;
using InBoxOutBoxExample.Application.Features.Queries.ProductQuerries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InBoxOutBoxExample.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductReadController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductReadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        GetAllProductQueryResponse response = await _mediator.Send(new GetAllProductQueryRequest());
        if (!response.Success) return BadRequest(response);
        return Ok(response);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetProductById([FromQuery] GetProductByIdQueryRequest request)
    {
        GetProductByIdQueryResponse response = await _mediator.Send(request);
        if (!response.Success) return BadRequest(response);
        return Ok(response);
    }
}
