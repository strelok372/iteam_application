namespace ITeam.Application.Services.Exceptions.NotFoundExceptions;

public class ModuleNotFoundException : NotFoundException
{
    public const string name = "module";

    public ModuleNotFoundException(int moduleId) : base(moduleId, name) { }
}
