using ITeam.Application.Mapper;
using ITeam.Application.Services.Exceptions.NotFoundExceptions;
using ITeam.Application.Services.Modules;
using ITeam.DataAccess.Models;
using ITeam.DataAccess.Repositories.Modules;
using ITeam.DataAccess.Repositories.Products;
using ITeam.Presentation.DTOs;

namespace ITeam.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IModuleRepository _moduleRepository;
    private readonly IMapper<ProductDto, ProductEntity> _productMapper;

    public ProductService(IProductRepository productRepository, IModuleRepository moduleRepository, IMapper<ProductDto, ProductEntity> productMapper)
    {
        _productRepository = productRepository;
        _moduleRepository = moduleRepository;
        _productMapper = productMapper;
    }

    public async Task<ProductDto> AddProductAsync(ProductDto product)
    {
        if (!await _moduleRepository.IsModuleExist(product.ModuleId))
            throw new ModuleNotFoundException(product.ModuleId);

        var newProduct = await _productRepository.AddProductAsync(_productMapper.ToEntity(product) with { Id = 0 });
        return _productMapper.ToDto(newProduct);
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

        return (await _productRepository.GetConnectedProductsAsync(productId)).Select(_productMapper.ToDto);
    }

    public async Task<ProductDto> GetProductByIdAsync(int productId)
    {
        return _productMapper.ToDto(await _productRepository.GetProductAsync(productId) ?? throw new ProductNotFoundException(productId));
    }

    public async Task<IEnumerable<ProductDto>> GetProductsInModuleAsync(int moduleId)
    {
        return (await _productRepository.GetProductsInModuleAsync(moduleId)).Select(_productMapper.ToDto);
    }

    public async Task<IEnumerable<ProductDto>> GetPurchasedProductsAsync(int userId)
    {
        return (await _productRepository.GetPurchasedProductsAsync(userId)).Select(_productMapper.ToDto);
    }

    public async Task UpdateProductAsync(ProductDto product)
    {
        if (!await _moduleRepository.IsModuleExist(product.ModuleId))
            throw new ModuleNotFoundException(product.ModuleId);

        await _productRepository.UpdateProductAsync(_productMapper.ToEntity(product));
    }
}
