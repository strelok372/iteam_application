using ITeam.DataAccess.Models;

namespace ITeam.DataAccess.Repositories.Modules;

public interface IModuleRepository
{
    Task<IEnumerable<ModuleEntity>> GetAllModulesAsync();
    Task<ModuleEntity?> GetModuleByIdAsync(int serviceId);
    Task<ModuleEntity> AddModuleAsync(ModuleEntity service);
    Task UpdateModuleAsync(ModuleEntity service);
    Task DeleteModuleAsync(ModuleEntity service);
    Task<ModuleTypeEntity?> GetModuleTypeByIdAsync(int id);
    Task<bool> IsModuleExist(int moduleId);
    Task<bool> IsModuleTypeExist(int moduleTypeId);
}
