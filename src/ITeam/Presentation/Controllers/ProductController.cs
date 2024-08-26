using ITeam.Application.Services.Products;
using Microsoft.AspNetCore.Mvc;
using ITeam.Presentation.DTOs;
using ITeam.Application.Services.Exceptions.NotFoundExceptions;

namespace ITeam.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService) => _productService = productService;

    [HttpGet("module/{moduleId}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsInModule(int moduleId)
    {
        try
        {
            return Ok(await _productService.GetProductsInModuleAsync(moduleId));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex);
        }
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<ProductDto>> GetProductById(int productId)
    {
        try
        {
            return await _productService.GetProductByIdAsync(productId);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex);
        }
    }

    [HttpGet("{user/{userId}/PurchasedProducts}")] // нормальный ли путь
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetPurchasedProducts(int userId)
    {
        try
        {
            return Ok(await _productService.GetPurchasedProductsAsync(userId));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex);
        }
    }

    [HttpGet("{productId}/ConnectedProducts")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetConnectedProducts(int productId)
    {
        try
        {
            return Ok(await _productService.GetConnectedProductsAsync(productId));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> AddProduct(ProductDto product)
    {

        try
        {
            return CreatedAtAction(nameof(GetProductById), await _productService.AddProductAsync(product));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProduct(ProductDto product)
    {

        try
        {
            await _productService.UpdateProductAsync(product);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex);
        }
    }

    [HttpDelete("{productId}")]
    public async Task<ActionResult> DeleteProduct(int productId)
    {

        try
        {
            await _productService.DeleteProductAsync(productId);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex);
        }
    }
}
