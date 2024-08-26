using ITeam.Application.Services.Exceptions.NotFoundExceptions;
using ITeam.DataAccess.Repositories.Modules;
using ITeam.Presentation.DTOs;

namespace ITeam.Application.Services.Modules;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;

    public ModuleService(IModuleRepository serviceRepository) => _moduleRepository = serviceRepository;

    public async Task<ModuleDto> AddModuleAsync(ModuleDto module)
    {
        if (_moduleRepository.GetModuleTypeByIdAsync(module.ModuleTypeId) is null)
            throw new ModuleTypeNotFoundException(module.ModuleTypeId);

        var newModule = await _moduleRepository.AddModuleAsync(module.ToModuleEntity() with { Id = 0 });

        return ModuleDto.FromModuleEntity(newModule);
    }

    public async Task DeleteModuleAsync(int moduleId)
    {
        await _moduleRepository.DeleteModuleAsync(
            await _moduleRepository.GetModuleByIdAsync(moduleId) ?? throw new ModuleNotFoundException(moduleId));
    }

    public async Task<IEnumerable<ModuleDto>> GetAllModulesAsync()
    {
        return (await _moduleRepository.GetAllModulesAsync()).Select(module => ModuleDto.FromModuleEntity(module));
    }

    public async Task<ModuleDto> GetModuleAsync(int moduleId)
    {
        return ModuleDto.FromModuleEntity(await _moduleRepository.GetModuleByIdAsync(moduleId) ?? throw new ModuleNotFoundException(moduleId));
    }

    public async Task UpdateModuleDescriptionAsync(int moduleId, string description)
    {
        var module = await _moduleRepository.GetModuleByIdAsync(moduleId) ?? throw new ModuleNotFoundException(moduleId);
        await _moduleRepository.UpdateModuleAsync(module with { Description = description });
    }

    public async Task UpdateModuleTypeAsync(int moduleId, int moduleTypeId)
    {
        var module = await _moduleRepository.GetModuleByIdAsync(moduleId) ?? throw new ModuleNotFoundException(moduleId);

        if (_moduleRepository.GetModuleTypeByIdAsync(moduleTypeId) is null)
            throw new ModuleTypeNotFoundException(moduleTypeId);

        await _moduleRepository.UpdateModuleAsync(module with { ModuleTypeId = moduleTypeId });
    }
}
