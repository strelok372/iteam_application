namespace ITeam.Application.Services.Exceptions.NotFoundException
{
    public class UserStatusNotFoundException : NotFoundExeption
    {
        public const string name = "userStatus";
        public UserStatusNotFoundException(int userStatusId) : base(userStatusId, "UserStatus") { }
    }
}
