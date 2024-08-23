using ITeam.DataAccess.Models;

namespace ITeam.DataAccess.Repositories
{
    public class UserStatusRepository : Repository<UserStatus>, IUserStatusRepository
    {
        public UserStatusRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
