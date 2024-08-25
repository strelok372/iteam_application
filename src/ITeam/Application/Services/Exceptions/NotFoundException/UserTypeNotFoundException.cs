namespace ITeam.Application.Services.Exceptions.NotFoundException
{
    public class UserTypeNotFoundException : NotFoundException
    {
        public const string name = "userType";
        public UserTypeNotFoundException(int userTypeId) : base(userTypeId, "UserType") { }
    }
}
