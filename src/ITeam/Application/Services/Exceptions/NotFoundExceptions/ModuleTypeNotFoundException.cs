namespace ITeam.Application.Services.Exceptions.NotFoundExceptions;

public class ModuleTypeNotFoundException : NotFoundException
{
    public const string name = "ModuleType";

    public ModuleTypeNotFoundException(int moduleTypeId) : base(moduleTypeId, name) { }
}
