using ITeam.DataAccess.Models;

namespace ITeam.Application.DTOs;

public record ModuleDto
{
    public int Id { get; set; }
    public int ServiceTypeId { get; set; }
    public string? Description { get; set; }

    public ModuleEntity ToServiceEntity()
    {
        return new ModuleEntity()
        {
            Id = Id,
            ModuleTypeId = ServiceTypeId,
            Description = Description
        };
    }

    public static ModuleDto FromServiceEntity(ModuleEntity serviceEntity)
    {
        return new ModuleDto()
        {
            Id = serviceEntity.Id,
            ServiceTypeId = serviceEntity.ModuleTypeId,
            Description = serviceEntity.Description
        };
    }
}
