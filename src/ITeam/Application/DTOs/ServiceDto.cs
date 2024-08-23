using ITeam.DataAccess.Models;

namespace ITeam.Application.DTOs;

public record ServiceDto
{
    public int Id { get; set; }
    public int ServiceTypeId { get; set; }
    public string? Description { get; set; }

    public ServiceEntity ToServiceEntity()
    {
        return new ServiceEntity()
        {
            Id = Id,
            ServiceTypeId = ServiceTypeId,
            Description = Description
        };
    }

    public static ServiceDto FromServiceEntity(ServiceEntity serviceEntity)
    {
        return new ServiceDto()
        {
            Id = serviceEntity.Id,
            ServiceTypeId = serviceEntity.ServiceTypeId,
            Description = serviceEntity.Description
        };
    }
}
