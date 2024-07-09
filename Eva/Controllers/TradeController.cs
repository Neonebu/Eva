using Eva.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eva.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpPost("buy")]
        public async Task<IActionResult> BuyShares(string userEmail, int portfolioId, string symbol, int quantity)
        {
            var result = await _tradeService.BuyShares(userEmail, portfolioId, symbol, quantity);
            if (result)
            {
                return Ok("Trade successful");
            }
            return BadRequest("Trade failed");
        }

        [HttpPost("sell")]
        public async Task<IActionResult> SellShares(string userEmail, int portfolioId, string symbol, int quantity)
        {
            var result = await _tradeService.SellShares(userEmail, portfolioId, symbol, quantity);
            if (result)
            {
                return Ok("Trade successful");
            }
            return BadRequest("Trade failed");
        }
    }
}
