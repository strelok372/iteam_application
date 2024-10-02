using System;
using ITeam.Application.Mapper;
using ITeam.DataAccess.Models;
using ITeam.Presentation.DTOs;

namespace ITeam.Application.Services.Modules;

public class ModuleMapper : IMapper<ModuleDto, ModuleEntity>
{
    public ModuleDto ToDto(ModuleEntity entity)
    {
        return new ModuleDto()
        {
            Id = entity.Id,
            ModuleTypeId = entity.ModuleTypeId,
            Description = entity.Description
        };
    }

    public ModuleEntity ToEntity(ModuleDto dto)
    {
        return new ModuleEntity()
        {
            Id = dto.Id,
            ModuleTypeId = dto.ModuleTypeId,
            Description = dto.Description
        };
    }
}
