using ITeam.DataAccess.Models;

namespace ITeam.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user); //регистрация

        Task UpdatePasswordAsync(int userId, string newPassword); 
        Task UpdateNameAsync(int userId, string newName);
        Task UpdateUserTypeAsync(int userId, int newUserTypeId);
        Task UpdateUserStatusAsync(int userId, int newUserStatusId);
        Task UpdateBalanceAsync(int userId, double newBalance);

        Task DeleteUserAsync(int id);
    }
}
