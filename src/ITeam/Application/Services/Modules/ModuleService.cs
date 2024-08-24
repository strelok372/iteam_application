using ITeam.Application.Services.Excaptions;
using ITeam.Presentation.DTOs;

namespace ITeam.Application.Services.Modules;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _serviceRepository;

    public ModuleService(IModuleRepository serviceRepository) => _serviceRepository = serviceRepository;

    public async Task<ModuleDto> AddModuleAsync(ModuleDto service)
    {
        if (_serviceRepository.GetServiceTypeByIdAsync(service.ServiceTypeId) is null)
            throw new Exception("ServiceTypeId не существует");

        var newService = await _serviceRepository.AddServiceAsync(service.ToServiceEntity() with { Id = 0 });

        return ModuleDto.FromServiceEntity(newService);
    }

    public async Task DeleteModuleAsync(int serviceId)
    {
        await _serviceRepository.DeleteServiceAsync(
            await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId));
    }

    public async Task<IEnumerable<ModuleDto>> GetAllModulesAsync()
    {
        return (await _serviceRepository.GetAllServicesAsync()).Select(service => ModuleDto.FromServiceEntity(service));
    }

    public async Task<ModuleDto> GetModuleAsync(int serviceId)
    {
        return ModuleDto.FromServiceEntity(await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId));
    }

    public async Task UpdateModuleDescriptionAsync(int serviceId, string description)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId);
        await _serviceRepository.UpdateServiceAsync(service with { Description = description });
    }

    public async Task UpdateModuleTypeAsync(int serviceId, int serviceTypeId)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(serviceId) ?? throw new ServiceNotFoundExeption(serviceId);

        if (_serviceRepository.GetServiceTypeByIdAsync(serviceTypeId) is null)
            throw new ServiceTypeNotFoundExeption(serviceTypeId);

        await _serviceRepository.UpdateServiceAsync(service with { ModuleTypeId = serviceTypeId });
    }
}
