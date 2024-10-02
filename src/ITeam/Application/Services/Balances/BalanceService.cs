using ITeam.DataAccess.Data.Enums;
using ITeam.DataAccess.Models;
using ITeam.DataAccess.Repositories.Balance;
using ITeam.DataAccess.Repositories.Users;
using ITeam.Presentation.DTOs.Balance;
using Microsoft.OpenApi.Models;

namespace ITeam.Application.Services.Balances
{
    public class BalanceService : IBalanceService
    {
        private readonly IUsersRepository _usersRepository;

        private readonly IBalanceRepository _balanceRepository;
        //надо добавить в конструктор
        //private readonly IProdactRepository _prodactRepository;

        public BalanceService(IBalanceRepository balanceRepository, IUsersRepository usersRepository)
        {
            _balanceRepository = balanceRepository;
            _usersRepository = usersRepository;
            //_prodactRepository  = prodactRepository;
        }

        public async Task<decimal> GetBalanceAsync(int userId)
        {
            var user = await _usersRepository.GetUserByIdAsync(userId);
            return user.Balance;
        }

        public async Task<UserBalanceDto> TopUpBalanceAsync(TopUpRequestDto dto)
        {
            if (dto.Amount <= 0 || dto.Amount > 100000)
            {
                throw new ArgumentException("Amount must be between 0 and 100,000.", nameof(dto.Amount));
            }

            var user = await _usersRepository.GetUserByIdAsync(dto.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            user.Balance += dto.Amount;


            var operation = new OperationUsersEntity
            {
                UserId = dto.UserId,
                OperationTypeId = (int)OperationTypes.Replenishment,
                Amount = dto.Amount,
                OperationDate = DateTime.UtcNow
            };

            await _usersRepository.UpdateUserAsync(user);
            await _balanceRepository.AddOperationAsync(operation);

            return new UserBalanceDto{ UserId=user.Id, Balance = user.Balance };
        }
        public async Task<UserBalanceDto> ProcessPurchaseAsync(PurchaseRequestDto purchaseRequest)
        {
            // Получаем пользователя
            var user = await _usersRepository.GetUserByIdAsync(purchaseRequest.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            //Закоментирована работа с продуктами, при слиянии с товарами и услугами протестить
            //var product = await _prodactRepository.GetProductAsync(purchaseRequest.ProductId);
            //if (product == null)
            //{
            //    throw new KeyNotFoundException("Product not found");
            //}
            //if (user.Balance < product.Price)
            //{
            //    throw new InvalidOperationException("Insufficient balance to complete the purchase.");
            //}
            //user.Balance -= product.Price;

            await _usersRepository.UpdateUserAsync(user);

            // Создаем и сохраняем запись о транзакции
           
            var operation = new OperationUsersEntity
            {
                UserId = user.Id,
                OperationTypeId = (int)OperationTypes.Purchase,
                //Amount = -product.Price,
                OperationDate = DateTime.UtcNow
            };
            await _balanceRepository.AddOperationAsync(operation);
            
            var purchase = new UserPurchaseEntity
            {
                UserId = user.Id,
                OperationId = operation.Id,
                //ProductId = product.Id
                PurchaseDate = DateTime.UtcNow
            };
            await _balanceRepository.AddPurchaseAsync(purchase);
            return new UserBalanceDto
            {
                UserId = user.Id,
                Balance = user.Balance
            };
        }

    }

}
