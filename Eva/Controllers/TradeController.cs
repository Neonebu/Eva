using Eva.Dtos;
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
        public async Task<IActionResult> BuyShares([FromBody] BuyRequest request)
        {
            var result = await _tradeService.BuyShares(request.UserEmail, request.PortfolioId, request.Symbol, request.Quantity);
            if (result)
            {
                return Ok("Trade successful");
            }
            return BadRequest("Trade failed");
        }

        [HttpPost("sell")]
        public async Task<IActionResult> SellShares([FromBody] SellRequest request)
        {
            var result = await _tradeService.SellShares(request.UserEmail, request.PortfolioId, request.Symbol, request.Quantity);
            if (result)
            {
                return Ok("Trade successful");
            }
            return BadRequest("Trade failed");
        }
    }
}
