using ITeam.DataAccess.Models;

namespace ITeam.DataAccess.Repositories.Balance
{
    public interface IBalanceRepository
    {
        Task AddOperationAsync(OperationUsersEntity operation);
        Task<IEnumerable<OperationUsersEntity>> GetOperationsByUserIdAsync(int userId);    
        Task AddPurchaseAsync(UserPurchaseEntity purchase);
    }
}
