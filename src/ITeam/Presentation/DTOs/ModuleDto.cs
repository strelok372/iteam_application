using ITeam.DataAccess.Models;

namespace ITeam.Presentation.DTOs;

public record ModuleDto
{
    public int Id { get; set; }
    public int ModuleTypeId { get; set; }
    public string? Description { get; set; }
}
