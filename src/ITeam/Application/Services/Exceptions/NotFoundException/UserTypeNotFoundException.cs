namespace ITeam.Application.Services.Exceptions.NotFoundException
{
    public class UserTypeNotFoundException : NotFoundExeption
    {
        public const string name = "userType";
        public UserTypeNotFoundException(int userTypeId) : base(userTypeId, "UserType") { }
    }
}
