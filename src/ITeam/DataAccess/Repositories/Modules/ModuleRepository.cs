using ITeam.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ITeam.DataAccess.Repositories.Modules;

public class ModuleRepository : IModuleRepository
{
    private readonly ApplicationContext _context;
    public ModuleRepository(ApplicationContext context) => _context = context;

    public async Task<ModuleEntity> AddModuleAsync(ModuleEntity service)
    {
        await _context.Modules.AddAsync(service);
        await _context.SaveChangesAsync();
        return service;
    }

    public async Task DeleteModuleAsync(ModuleEntity service)
    {
        _context.Modules.Remove(service);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ModuleEntity>> GetAllModulesAsync()
    {
        return await _context.Modules.ToArrayAsync();
    }

    public async Task<ModuleEntity?> GetModuleByIdAsync(int serviceId)
    {
        return await _context.Modules.FirstOrDefaultAsync(service => service.Id == serviceId);
    }

    public async Task UpdateModuleAsync(ModuleEntity service)
    {
        _context.Modules.Update(service);
        await _context.SaveChangesAsync();
    }

    public async Task<ModuleTypeEntity?> GetModuleTypeByIdAsync(int id)
    {
        return await _context.ModuleTypes.FindAsync(id);
    }

    public async Task<bool> IsModuleExist(int moduleId)
    {
        return await _context.Modules.AnyAsync(module => module.Id == moduleId);
    }

    public async Task<bool> IsModuleTypeExist(int moduleTypeId)
    {
        return await _context.ModuleTypes.AnyAsync(moduleType => moduleType.Id == moduleTypeId);
    }
}
