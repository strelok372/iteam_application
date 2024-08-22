using ITeam.DataAccess.Models;

namespace ITeam.DataAccess.Repositories;

public interface IServiceRepository
{
    Task<ServiceEntity?> GetServiceByIdAsync(int serviceId);
    Task<IEnumerable<ServiceEntity>> GetAllServicesAsync();
    Task AddServiceAsync(ServiceEntity service);
    Task UpdateServiceAsync(ServiceEntity service);
    Task DeleteServiceAsync(int serviceId);
}
