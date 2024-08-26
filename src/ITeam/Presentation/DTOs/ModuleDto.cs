using ITeam.DataAccess.Models;

namespace ITeam.Presentation.DTOs;

public record ModuleDto
{
    public int Id { get; set; }
    public int ModuleTypeId { get; set; }
    public string? Description { get; set; }

    public ModuleEntity ToModuleEntity()
    {
        return new ModuleEntity()
        {
            Id = Id,
            ModuleTypeId = ModuleTypeId,
            Description = Description
        };
    }

    public static ModuleDto FromModuleEntity(ModuleEntity moduleEntity)
    {
        return new ModuleDto()
        {
            Id = moduleEntity.Id,
            ModuleTypeId = moduleEntity.ModuleTypeId,
            Description = moduleEntity.Description
        };
    }
}
