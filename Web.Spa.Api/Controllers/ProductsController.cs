using Microsoft.AspNetCore.Mvc;
using Web.Spa.Api.Contracts.Responses;
using Web.Spa.Api.Services;

namespace Web.Spa.Api.Controllers;

[ApiController]
[Route("products")]
public class ProductsController(IProductService products) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var items = await products.ListAsync(ct);
        var dto = items.Select(p => new ProductDto
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            Price = p.Price,
            Image = p.Image,
        });
        return Ok(dto);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOne([FromRoute] int id, CancellationToken ct)
    {
        var p = await products.GetAsync(id, ct);
        if (p is null)
            return NotFound();
        return Ok(
            new ProductDto
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                Image = p.Image,
            }
        );
    }
}
