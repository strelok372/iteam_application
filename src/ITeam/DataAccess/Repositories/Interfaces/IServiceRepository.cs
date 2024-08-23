using ITeam.DataAccess.Models;

namespace ITeam.DataAccess.Repositories;

public interface IServiceRepository
{
    Task<IEnumerable<ServiceEntity>> GetAllServicesAsync();
    Task<ServiceEntity?> GetServiceByIdAsync(int serviceId);
    Task<ServiceEntity> AddServiceAsync(ServiceEntity service);
    Task UpdateServiceAsync(ServiceEntity service);
    Task DeleteServiceAsync(ServiceEntity service);
}
