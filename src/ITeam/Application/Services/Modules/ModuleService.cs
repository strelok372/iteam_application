using ITeam.Application.Mapper;
using ITeam.Application.Services.Exceptions.NotFoundExceptions;
using ITeam.DataAccess.Models;
using ITeam.DataAccess.Repositories.Modules;
using ITeam.Presentation.DTOs;

namespace ITeam.Application.Services.Modules;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;
    private readonly IMapper<ModuleDto, ModuleEntity> _moduleMapper;

    public ModuleService(IModuleRepository serviceRepository, IMapper<ModuleDto, ModuleEntity> moduleMapper)
    {
        _moduleRepository = serviceRepository;
        _moduleMapper = moduleMapper;
    }

    public async Task<ModuleDto> AddModuleAsync(ModuleDto module)
    {
        if (!await _moduleRepository.IsModuleTypeExist(module.ModuleTypeId))
            throw new ModuleTypeNotFoundException(module.ModuleTypeId);

        var newModule = await _moduleRepository.AddModuleAsync(_moduleMapper.ToEntity(module) with { Id = 0 });

        return _moduleMapper.ToDto(newModule);
    }

    public async Task DeleteModuleAsync(int moduleId)
    {
        await _moduleRepository.DeleteModuleAsync(
            await _moduleRepository.GetModuleByIdAsync(moduleId) ?? throw new ModuleNotFoundException(moduleId));
    }

    public async Task<IEnumerable<ModuleDto>> GetAllModulesAsync()
    {
        return (await _moduleRepository.GetAllModulesAsync()).Select(module => _moduleMapper.ToDto(module));
    }

    public async Task<ModuleDto> GetModuleAsync(int moduleId)
    {
        return _moduleMapper.ToDto(await _moduleRepository.GetModuleByIdAsync(moduleId) ?? throw new ModuleNotFoundException(moduleId));
    }

    public async Task UpdateModuleAsync(ModuleDto module)
    {
        if (!await _moduleRepository.IsModuleExist(module.Id))
            throw new ModuleNotFoundException(module.Id);

        if (!await _moduleRepository.IsModuleTypeExist(module.ModuleTypeId))
            throw new ModuleTypeNotFoundException(module.Id);

        await _moduleRepository.UpdateModuleAsync(_moduleMapper.ToEntity(module));
    }
}
