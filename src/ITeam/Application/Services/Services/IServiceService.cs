using ITeam.Application.DTOs;

namespace ITeam.Application.Services.Services;

public interface IServiceService
{
    public Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
    public Task<ServiceDto> GetServiceAsync(int serviceId);
    public Task<ServiceDto> AddServiceAsync(ServiceDto service);
    public Task UpdateServiceDescriptionAsync(int serviceId, string description);
    public Task UpdateServiceServiceTypeAsync(int serviceId, int serviceTypeId);
    public Task DeleteServiceAsync(int serviceId);
}
