namespace ITeam.Application.Services.Exceptions.NotFoundException
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id, string objectName) : base($"{objectName} with id = {id} not found") { }
    }
}
