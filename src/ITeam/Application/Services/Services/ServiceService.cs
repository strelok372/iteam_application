using ITeam.Application.DTOs;
using ITeam.Application.Services.Excaptions;
using ITeam.DataAccess.Models;
using ITeam.DataAccess.Repositories.Services;

namespace ITeam.Application.Services.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceService(IServiceRepository serviceRepository) => _serviceRepository = serviceRepository;

    public async Task<ServiceDto> AddServiceAsync(ServiceDto service)
    {
        if (_serviceRepository.GetServiceTypeByIdAsync(service.ServiceTypeId) is null)
            throw new Exception("ServiceTypeId не существует");

        var newService = await _serviceRepository.AddServiceAsync(service.ToServiceEntity() with {Id = 0 });

        return ServiceDto.FromServiceEntity(newService);
    }

    public async Task DeleteServiceAsync(int serviceId)
    {
        await _serviceRepository.DeleteServiceAsync(
            await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId));
    }

    public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
    {
        return (await _serviceRepository.GetAllServicesAsync()).Select(service => ServiceDto.FromServiceEntity(service));
    }

    public async Task<ServiceDto> GetServiceAsync(int serviceId)
    {
        return ServiceDto.FromServiceEntity(await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId));
    }

    public async Task UpdateServiceDescriptionAsync(int serviceId, string description)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId);
        await _serviceRepository.UpdateServiceAsync(service with { Description = description });
    }

    public async Task UpdateServiceServiceTypeAsync(int serviceId, int serviceTypeId)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId);

        if (_serviceRepository.GetServiceTypeByIdAsync(serviceTypeId) is null)
            throw new ServiceTypeNotFoundExeption(serviceTypeId);

        await _serviceRepository.UpdateServiceAsync(service with { ServiceTypeId = serviceTypeId });
    }
}
