using ITeam.DataAccess.Models;

namespace ITeam.DataAccess.Repositories.Products;

public interface IProductRepository
{
    Task<ProductEntity> AddProductAsync(ProductEntity product);
    Task<ProductEntity?> GetProductAsync(int productId);
    Task<IEnumerable<ProductEntity>> GetProductsInModuleAsync(int moduleId);
    Task<IEnumerable<ProductEntity>> GetPurchasedProductsAsync(int userId);
    Task<IEnumerable<ProductEntity>> GetConnectedProductsAsync(int productId);
    Task DeleteProductAsync(ProductEntity product);
    Task UpdateProductAsync(ProductEntity product);
}
