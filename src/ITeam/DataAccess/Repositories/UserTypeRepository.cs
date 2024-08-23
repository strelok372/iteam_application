using ITeam.DataAccess.Models;

namespace ITeam.DataAccess.Repositories
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
