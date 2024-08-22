namespace ITeam.DataAccess.Models;

public class ServiceEntity
{
    public int Id { get; set; }

    public int ServiceTypeId { get; set; }
    public ServiceTypeEntity ServiceType { get; set; }

    public string? Description { get; set; }
}
