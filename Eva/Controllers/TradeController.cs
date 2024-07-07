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

        [HttpPost("Buy")]
        public async Task<IActionResult> PostBuyShares(int portfolioId, string symbol, int quantity)
        {
            var result = await _tradeService.BuyShares(portfolioId, symbol, quantity);
            if (result)
            {
                return Ok("Trade successful");
            }
            return BadRequest("Trade failed");
        }

        [HttpPost("Sell")]
        public async Task<IActionResult> PostSellShares(int portfolioId, string symbol, int quantity)
        {
            var result = await _tradeService.SellShares(portfolioId, symbol, quantity);
            if (result)
            {
                return Ok("Trade successful");
            }
            return BadRequest("Trade failed");
        }
    }
}
