using ITeam.Presentation.DTOs;

namespace ITeam.Application.Services.Products;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsInModuleAsync(int moduleId);
    Task<ProductDto> GetProductByIdAsync(int productId);
    Task<IEnumerable<ProductDto>> GetPurchasedProductsAsync(int userId);
    Task<IEnumerable<ProductDto>> GetConnectedProductsAsync(int productId);
    Task<ProductDto> AddProductAsync(ProductDto product);
    Task UpdateProductAsync(ProductDto product);
    Task DeleteProductAsync(int productId);
}
