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

    public async Task<ServiceDto> AddServiceAsync(ServiceDto service)
    {
        if (_serviceTypeRepository.GetServiceTypeByIdAsync(service.ServiceTypeId) is null)
            throw new Exception("ServiceTypeId не существует");

        var newService = await _serviceRepository.AddServiceAsync(new ServiceEntity()
        {
            Id = 0,
            Description = service.Description,
            ServiceTypeId = service.ServiceTypeId
        });

        return new ServiceDto(newService);
    }

    public async Task DeleteServiceAsync(int serviceId)
    {
        await _serviceRepository.DeleteServiceAsync(
            await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId));
    }

    public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
    {
        return (await _serviceRepository.GetAllServicesAsync()).Select(service => new ServiceDto(service));
    }

    public async Task<ServiceDto> GetServiceAsync(int serviceId)
    {
        return new ServiceDto(await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId));
    }

    public async Task UpdateServiceDescriptionAsync(int serviceId, string description)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId);
        await _serviceRepository.UpdateServiceAsync(service with { Description = description });
    }

    public async Task UpdateServiceServiceTypeAsync(int serviceId, int serviceTypeId)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId);

        if (_serviceTypeRepository.GetServiceTypeByIdAsync(serviceTypeId) is null)
            throw new ServiceTypeNotFoundExeption(serviceTypeId);

        await _serviceRepository.UpdateServiceAsync(service with { ServiceTypeId = serviceTypeId });
    }
}
