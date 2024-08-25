namespace ITeam.Application.Services.Exceptions.NotFoundException
{
    public class UserStatusNotFoundException : NotFoundException
    {
        public const string name = "userStatus";
        public UserStatusNotFoundException(int userStatusId) : base(userStatusId, "UserStatus") { }
    }
}
