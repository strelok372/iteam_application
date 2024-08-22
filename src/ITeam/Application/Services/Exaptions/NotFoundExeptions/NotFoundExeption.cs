namespace ITeam.Application.Services.Exaptions;

public class NotFoundExeption : Exception
{
    public NotFoundExeption(int id, string objectName) : base($"{objectName} with id = {id} not found") { }
}
