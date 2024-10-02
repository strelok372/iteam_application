using ITeam.Presentation.DTOs.Balance;

namespace ITeam.Application.Services.Balances
{
    public interface IBalanceService
    {
        Task<decimal> GetBalanceAsync(int userId);
        Task<UserBalanceDto> TopUpBalanceAsync(TopUpRequestDto dto);
        Task<UserBalanceDto> ProcessPurchaseAsync(PurchaseRequestDto dto);

    }
}
