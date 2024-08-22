using ITeam.Application.DTOs;
using ITeam.Application.Services.Exaptions;
using ITeam.DataAccess.Models;
using ITeam.DataAccess.Repositories;

namespace ITeam.Application.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IServiceTypeRepository _serviceTypeRepository;

    public ServiceService(IServiceRepository serviceRepository, IServiceTypeRepository serviceTypeRepository)
    {
        _serviceRepository = serviceRepository;
        _serviceTypeRepository = serviceTypeRepository;
    }

    public async Task AddServiceAsync(ServiceDto service)
    {
        if (_serviceTypeRepository.GetByIdAsync(service.ServiceTypeId) is null)
            throw new Exception("ServiceTypeId не существует");

        await _serviceRepository.AddServiceAsync(new ServiceEntity() { Description = service.Description, ServiceTypeId = service.ServiceTypeId });
    }

    public async Task DeleteServiceAsync(int serviceId)
    {
        if (_serviceRepository.GetServiceByIdAsync(serviceId) is null)
            throw new ServiceNotFoundExeption(serviceId);

        await _serviceRepository.DeleteServiceAsync(serviceId);
    }

    public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
    {
        return (await _serviceRepository.GetAllServicesAsync()).Select(service => new ServiceDto(service));
    }

    public async Task UpdateServiceDescriptionAsync(int serviceId, string description)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId);
        await _serviceRepository.UpdateServiceAsync(service with { Description = description });
    }

    public async Task UpdateServiceServiceTypeAsync(int serviceId, int serviceTypeId)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId);

        if (_serviceTypeRepository.GetByIdAsync(serviceTypeId) is null)
            throw new ServiceTypeNotFoundExeption(serviceTypeId);

        await _serviceRepository.UpdateServiceAsync(service with { ServiceTypeId = serviceTypeId });
    }
}
