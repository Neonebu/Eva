using Eva.Context;
using Eva.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Eva.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly EvaDbContext _context;

        public TradeRepository(EvaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Trade trade)
        {
            await _context.Trades.AddAsync(trade);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetTotalBoughtAsync(int portfolioId, string symbol)
        {
            return await _context.Trades
                .Where(t => t.PortfolioId == portfolioId && t.Symbol == symbol && t.TradeType == TradeType.BUY)
                .SumAsync(t => t.Quantity);
        }

        public async Task<int> GetTotalSoldAsync(int portfolioId, string symbol)
        {
            return await _context.Trades
                .Where(t => t.PortfolioId == portfolioId && t.Symbol == symbol && t.TradeType == TradeType.SELL)
                .SumAsync(t => t.Quantity);
        }
    }
}
