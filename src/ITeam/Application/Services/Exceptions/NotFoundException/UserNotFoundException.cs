namespace ITeam.Application.Services.Exceptions.NotFoundException
{
   
    public class UserNotFoundException : NotFoundException
    {
        public const string name = "user";

        public UserNotFoundException(int userId) : base(userId, "User") { }
    }
}
