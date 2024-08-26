using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using ITeam.Application.Services.Exceptions.NotFoundExceptions;
using ITeam.DataAccess.Repositories.Modules;
using ITeam.DataAccess.Repositories.Products;
using ITeam.Presentation.DTOs;

namespace ITeam.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IModuleRepository _moduleRepository;

    public ProductService(IProductRepository productRepository) => _productRepository = productRepository;

    public async Task<ProductDto> AddProductAsync(ProductDto product)
    {
        CheckModuleIdExist(product.ModuleId);

        var newProduct = await _productRepository.AddProductAsync(product.ToEntity());
        return ProductDto.FromEntity(newProduct);
    }

    public async Task DeleteProductAsync(int productId)
    {
        await _productRepository.DeleteProductAsync(
            await _productRepository.GetProductAsync(productId) ?? throw new ProductNotFoundException(productId));
    }

    public async Task<IEnumerable<ProductDto>> GetConnectedProductsAsync(int productId)
    {
        if (await _productRepository.GetProductAsync(productId) is null)
            throw new ProductNotFoundException(productId);

        return (await _productRepository.GetConnectedProductsAsync(productId)).Select(ProductDto.FromEntity);
    }

    public async Task<ProductDto> GetProductByIdAsync(int productId)
    {
        return ProductDto.FromEntity(await _productRepository.GetProductAsync(productId)) ?? throw new ProductNotFoundException(productId);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsInModuleAsync(int moduleId)
    {
        return (await _productRepository.GetProductsInModuleAsync(moduleId)).Select(ProductDto.FromEntity);
    }

    public async Task<IEnumerable<ProductDto>> GetPurchasedProductsAsync(int userId)
    {
        return (await _productRepository.GetPurchasedProductsAsync(userId)).Select(ProductDto.FromEntity);
    }

    public async Task UpdateProductAsync(ProductDto product) /// нет проверок
    {
        CheckModuleIdExist(product.ModuleId);

        await _productRepository.UpdateProductAsync(product.ToEntity());
    }

    private async void CheckModuleIdExist(int moduleId)
    {
        if (await _moduleRepository.GetModuleByIdAsync(moduleId) is null)
            throw new ModuleNotFoundException(moduleId);
    }
}
