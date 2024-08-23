using ITeam.DataAccess.Models;

namespace ITeam.DataAccess.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
