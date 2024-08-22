using System;
using ITeam.DataAccess.Models;

namespace ITeam.Application.DTOs;

public record ServiceDto
{
    public int Id { get; set; }
    public int ServiceTypeId { get; set; }
    public string? Description { get; set; }

    public ServiceDto(ServiceEntity serviceEntity)
    {
        Id = serviceEntity.Id;
        ServiceTypeId = serviceEntity.ServiceTypeId;
        Description = serviceEntity.Description;
    }
}
