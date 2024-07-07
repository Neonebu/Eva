﻿using Eva.Services;
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
        public async Task<IActionResult> BuyShares(int portfolioId, string symbol, int quantity)
        {
            var result = await _tradeService.BuyShares(portfolioId, symbol, quantity);
            if (result)
            {
                return Ok("Trade successful");
            }
            return BadRequest("Trade failed");
        }

        [HttpPost("sell")]
        public async Task<IActionResult> SellShares(int portfolioId, string symbol, int quantity)
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
