using ITeam.Presentation.DTOs;

namespace ITeam.Application.Services.Modules;

public interface IModuleService
{
    public Task<IEnumerable<ModuleDto>> GetAllModulesAsync();
    public Task<ModuleDto> GetModuleAsync(int moduleId);
    public Task<ModuleDto> AddModuleAsync(ModuleDto module);
    public Task UpdateModuleDescriptionAsync(int moduleId, string description);
    public Task UpdateModuleTypeAsync(int moduleId, int moduleTypeId);
    public Task DeleteModuleAsync(int moduleId);
}
