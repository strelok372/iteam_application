using ITeam.DataAccess.Models;

namespace ITeam.DataAccess.Repositories.Users
{
    public interface IUsersRepository
    {
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        Task<UserEntity?> GetUserByIdAsync(int userId);
        Task<UserEntity> AddUserAsync(UserEntity user);
        Task UpdateUserAsync(UserEntity user);
        Task DeleteUserAsync(UserEntity user);
        Task<UserEntity> GetByEmailAsync(string email);

        Task<UserTypeEntity?> GetUserTypeByIdAsync(int userTypeId);
        Task<UserStatusEntity?> GetUserStatusByIdAsync(int userStatusId);

    }
}
