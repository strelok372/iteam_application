namespace ITeam.Application.Services.Exaptions;

public class ServiceTypeNotFoundExeption : NotFoundExeption
{
    public const string objectName = "ServiceType";

    public ServiceTypeNotFoundExeption(int serviceTypeId) : base(serviceTypeId, objectName) { }
}
