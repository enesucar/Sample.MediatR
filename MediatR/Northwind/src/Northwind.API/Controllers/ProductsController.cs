using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.API.Features.Products.Commands;
using Northwind.API.Features.Products.Queries;

namespace Northwind.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private ISender _mediator => HttpContext.RequestServices.GetRequiredService<ISender>();

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await _mediator.Send(new GetProductsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand request)
    {
        var result = await _mediator.Send(request);
        return Created("", result);
    }
}
