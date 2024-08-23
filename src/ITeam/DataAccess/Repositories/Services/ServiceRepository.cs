using ITeam.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace ITeam.DataAccess.Repositories.Services;

public class ServiceRepository : IServiceRepository
{
    private readonly ApplicationContext _context;
    public ServiceRepository(ApplicationContext context) => _context = context;

    public async Task<ServiceEntity> AddServiceAsync(ServiceEntity service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
        return service;
    }

    public async Task DeleteServiceAsync(ServiceEntity service)
    {
        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ServiceEntity>> GetAllServicesAsync()
    {
        return await _context.Services.ToArrayAsync();
    }

    public async Task<ServiceEntity?> GetServiceByIdAsync(int serviceId)
    {
        return await _context.Services.FirstOrDefaultAsync(service => service.Id == serviceId);
    }

    public async Task UpdateServiceAsync(ServiceEntity service)
    {
        _context.Services.Update(service);
        await _context.SaveChangesAsync();
    }

    public async Task<ServiceTypeEntity?> GetServiceTypeByIdAsync(int id)
    {
        return await _context.ServiceTypes.FindAsync(id);
    }
}
