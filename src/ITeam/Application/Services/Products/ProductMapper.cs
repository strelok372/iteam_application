using ITeam.Application.Mapper;
using ITeam.DataAccess.Models;
using ITeam.Presentation.DTOs;

namespace ITeam.Application.Services.Products;

public class ProductMapper : IMapper<ProductDto, ProductEntity>
{
    public ProductDto ToDto(ProductEntity entity)
    {
        return new ProductDto()
        {
            Id = entity.Id,
            ModuleId = entity.ModuleId,
            SequenceNumber = entity.SequenceNumber,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            MaterialLink = entity.MaterialLink,
            PreviewLink = entity.PreviewLink
        };
    }

    public ProductEntity ToEntity(ProductDto dto)
    {
        return new ProductEntity()
        {
            Id = dto.Id,
            ModuleId = dto.ModuleId,
            SequenceNumber = dto.SequenceNumber,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            MaterialLink = dto.MaterialLink,
            PreviewLink = dto.PreviewLink
        };
    }
}
