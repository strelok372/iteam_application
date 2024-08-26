using System;
using System.ComponentModel.DataAnnotations;
using ITeam.DataAccess.Models;

namespace ITeam.Presentation.DTOs;

public record ProductDto
{
    public int Id { get; set; }
    public int ModuleId { get; set; }

    [Range(1, int.MaxValue)]
    public int SequenceNumber { get; set; }

    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public string MaterialLink { get; set; }

    [Required]
    public string PreviewLink { get; set; }

    public ProductEntity ToEntity()
    {
        return new ProductEntity()
        {
            Id = Id,
            ModuleId = ModuleId,
            SequenceNumber = SequenceNumber,
            Name = Name,
            Description = Description,
            Price = Price,
            MaterialLink = MaterialLink,
            PreviewLink = PreviewLink
        };
    }

    public static ProductDto FromEntity(ProductEntity moduleEntity)
    {
        return new ProductDto()
        {
            Id = moduleEntity.Id,
            ModuleId = moduleEntity.ModuleId,
            SequenceNumber = moduleEntity.SequenceNumber,
            Name = moduleEntity.Name,
            Description = moduleEntity.Description,
            Price = moduleEntity.Price,
            MaterialLink = moduleEntity.MaterialLink,
            PreviewLink = moduleEntity.PreviewLink
        };
    }
}
