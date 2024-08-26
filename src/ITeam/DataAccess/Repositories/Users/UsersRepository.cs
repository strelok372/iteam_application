using ITeam.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ITeam.DataAccess.Repositories.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationContext _context;

        public UsersRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            return await _context.Users.ToArrayAsync();
        }

        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<UserEntity> AddUserAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task DeleteUserAsync(UserEntity user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserEntity user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserTypeEntity?> GetUserTypeByIdAsync(int id)
        {
            return await _context.UserTypes.FindAsync(id);
        }
        public async Task<UserStatusEntity?> GetUserStatusByIdAsync(int id)
        {
            return await _context.UserStatuses.FindAsync(id);
        }
    }
}
