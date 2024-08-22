namespace ITeam.Application.Services.Exaptions;

public class ServiceNotFoundExeption : NotFoundExeption
{
    public const string name = "service";

    public ServiceNotFoundExeption(int serviceId) : base(serviceId, "Service") { }
}
