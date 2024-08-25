namespace ITeam.Application.Services.Exceptions.NotFoundException
{
    public class NotFoundExeption : Exception
    {
        public NotFoundExeption(int id, string objectName) : base($"{objectName} with id = {id} not found") { }
    }
}
