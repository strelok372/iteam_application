using ITeam.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace ITeam.DataAccess.Repositories.Modules;

public class ModuleRepository : IModuleRepository
{
    private readonly ApplicationContext _context;
    public ModuleRepository(ApplicationContext context) => _context = context;

    public async Task<ModuleEntity> AddModuleAsync(ModuleEntity service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
        return service;
    }

    public async Task DeleteModuleAsync(ModuleEntity service)
    {
        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ModuleEntity>> GetAllModulesAsync()
    {
        return await _context.Services.ToArrayAsync();
    }

    public async Task<ModuleEntity?> GetModuleByIdAsync(int serviceId)
    {
        return await _context.Services.FirstOrDefaultAsync(service => service.Id == serviceId);
    }

    public async Task UpdateModuleAsync(ModuleEntity service)
    {
        _context.Services.Update(service);
        await _context.SaveChangesAsync();
    }

    public async Task<ModuleTypeEntity?> GetModuleTypeByIdAsync(int id)
    {
        return await _context.ServiceTypes.FindAsync(id);
    }
}
