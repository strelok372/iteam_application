namespace ITeam.Application.Services.Exceptions.NotFoundException
{
   
    public class UserNotFoundException : NotFoundExeption
    {
        public const string name = "user";

        public UserNotFoundException(int userId) : base(userId, "User") { }
    }
}
