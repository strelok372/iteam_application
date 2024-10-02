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
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsInModuleAsync(int moduleId)
    {
        try
        {
            return Ok(await _productService.GetProductsInModuleAsync(moduleId));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{productId}")]
    [ActionName(nameof(GetProductByIdAsync))]
    public async Task<ActionResult<ProductDto>> GetProductByIdAsync(int productId)
    {
        try
        {
            return await _productService.GetProductByIdAsync(productId);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("user/{userId}/PurchasedProducts")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetPurchasedProductsAsync(int userId)
    {
        try
        {
            return Ok(await _productService.GetPurchasedProductsAsync(userId));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{productId}/ConnectedProducts")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetConnectedProductsAsync(int productId)
    {
        try
        {
            return Ok(await _productService.GetConnectedProductsAsync(productId));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> AddProductAsync(ProductDto product)
    {
        try
        {
            var newProduct = await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProductByIdAsync), new { productId = newProduct.Id }, newProduct);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProductAsync(ProductDto product)
    {
        try
        {
            await _productService.UpdateProductAsync(product);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{productId}")]
    public async Task<ActionResult> DeleteProductAsync(int productId)
    {
        try
        {
            await _productService.DeleteProductAsync(productId);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
