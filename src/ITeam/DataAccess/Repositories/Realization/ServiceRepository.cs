using System.Data.Entity;
using ITeam.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ITeam.DataAccess.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly ApplicationContext _context;
    public ServiceRepository(ApplicationContext context) => _context = context;

    public async Task AddServiceAsync(ServiceEntity service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteServiceAsync(int serviceId)
    {
        _context.Services.Remove(await GetServiceByIdAsync(serviceId));
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
}
