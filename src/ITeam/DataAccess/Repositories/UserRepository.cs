using ITeam.DataAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace ITeam.DataAccess.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;            
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.Include(u => u.UserType).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.UserType).ToListAsync();
        }
        private async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePasswordAsync(int userId, string newPassword)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null) throw new Exception("User not found");

            user.Password = newPassword; 
            await UpdateUserAsync(user);
        }

        public async Task UpdateNameAsync(int userId, string newName)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null) throw new Exception("User not found");
            user.Name = newName;
            await UpdateUserAsync(user);
        }

        public async Task UpdateBalanceAsync(int userId, double newBalance)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null) throw new Exception("User not found");
            user.Balance = newBalance;
            await UpdateUserAsync(user);
        }
        public async Task UpdateUserTypeAsync(int userId, int newUserTypeId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null) throw new Exception("User not found");

            var userType = await _context.UserTypes.FindAsync(newUserTypeId);
            if (userType == null) throw new Exception("UserType not found");

            user.UserTypeId = newUserTypeId;
            user.UserType = userType;
            await UpdateUserAsync(user);
        }
        public async Task UpdateUserStatusAsync(int userId, int newUserStatusId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null) throw new Exception("User not found");

            var userStatus = await _context.UserStatuses.FindAsync(newUserStatusId);
            if (userStatus == null) throw new Exception("UserType not found");

            user.UserStatusId = newUserStatusId;
            user.UserStatus = userStatus;
            await UpdateUserAsync(user);            
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

