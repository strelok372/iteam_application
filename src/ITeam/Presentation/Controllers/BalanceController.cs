 using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ITeam.Application.Services.Balances;
using ITeam.Presentation.DTOs.Balance;

namespace ITeam.Presentation.Controllers
{   

    [ApiController]
    [Route("api/[controller]")]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpPost("topup")]
        public async Task<ActionResult<UserBalanceDto>> TopUpBalance([FromBody] TopUpRequestDto topUpRequest)
        {
            try
            {
                var result = await _balanceService.TopUpBalanceAsync(topUpRequest);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPost("purchase")]
        public async Task<ActionResult<UserBalanceDto>> ProcessPurchase([FromBody] PurchaseRequestDto purchaseRequest)
        {
            try
            {
                var result = await _balanceService.ProcessPurchaseAsync(purchaseRequest);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); 
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }

}
