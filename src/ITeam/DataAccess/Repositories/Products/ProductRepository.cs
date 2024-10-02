using ITeam.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ITeam.DataAccess.Repositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationContext _context;

    public ProductRepository(ApplicationContext context) => _context = context;

    public async Task<ProductEntity> AddProductAsync(ProductEntity product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task DeleteProductAsync(ProductEntity product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductEntity>> GetConnectedProductsAsync(int productId)
    {
        return await _context.ProductConnections
            .Where(pc => pc.FirstProductId == productId)
            .Select(pc => pc.SecondProduct)
            .ToArrayAsync();
    }

    public async Task<ProductEntity?> GetProductAsync(int productId)
    {
        return await _context.Products.FirstOrDefaultAsync(product => product.Id == productId);
    }

    public async Task<IEnumerable<ProductEntity>> GetProductsInModuleAsync(int moduleId)
    {
        return await _context.Products.Where(product => product.ModuleId == moduleId).ToArrayAsync();
    }

    public Task<IEnumerable<ProductEntity>> GetPurchasedProductsAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateProductAsync(ProductEntity product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}
