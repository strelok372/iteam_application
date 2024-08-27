using System.ComponentModel.DataAnnotations;

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
}
