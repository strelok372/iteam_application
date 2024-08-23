using System;
using ITeam.DataAccess.Models;

namespace ITeam.DataAccess.Repositories;

public class ServiceTypeRepository : IServiceTypeRepository
{
    private readonly ApplicationContext _context;

    public ServiceTypeRepository(ApplicationContext context) => _context = context;

    public async Task<ServiceTypeEntity?> GetServiceTypeByIdAsync(int id)
    {
        return await _context.ServiceTypes.FindAsync(id);
    }
}
