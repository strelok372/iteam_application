using ITeam.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ITeam.DataAccess.Repositories.Balance
{
    public class BalanceRepository:IBalanceRepository
    {
        private readonly ApplicationContext _context;

        public BalanceRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddOperationAsync(OperationUsersEntity operation)
        {
            _context.OperationUsers.Add(operation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OperationUsersEntity>> GetOperationsByUserIdAsync(int userId)
        {
            return await _context.OperationUsers
                .Where(op => op.UserId == userId)
                .ToListAsync();
        }

        public async Task AddPurchaseAsync(UserPurchaseEntity purchase)
        {
            _context.UserPurchases.Add(purchase);
            await _context.SaveChangesAsync();
        }
    }
}
