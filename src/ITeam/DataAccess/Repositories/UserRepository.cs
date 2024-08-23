using ITeam.DataAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace ITeam.DataAccess.Repositories
{
    public class UserRepository:Repository<User>, IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context) : base(context)
        {
           
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}

