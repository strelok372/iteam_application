using ITeam.Application.DTOs;

namespace ITeam.Application.Services;

public interface IServiceService
{
    public Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
    public Task AddServiceAsync(ServiceDto service);
    public Task UpdateServiceDescriptionAsync(int serviceId, string description);
    public Task UpdateServiceServiceTypeAsync(int serviceId, int serviceTypeId);
    public Task DeleteServiceAsync(int serviceId);
}
