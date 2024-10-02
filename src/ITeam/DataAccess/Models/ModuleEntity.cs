namespace ITeam.DataAccess.Models;

public record ModuleEntity
{
    public int Id { get; set; }

    public int ModuleTypeId { get; set; }
    public ModuleTypeEntity ModuleType { get; set; }

    public string? Description { get; set; }
}
