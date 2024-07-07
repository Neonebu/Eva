using Eva.Context;
using Eva.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Eva.Services
{
    public class TradeService : ITradeService
    {
        private readonly EvaDbContext _context;

        public TradeService(EvaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> BuyShares(int portfolioId, string symbol, int quantity)
        {
            var share = await _context.Shares.FirstOrDefaultAsync(s => s.Symbol == symbol);
            if (share == null) return false;

            var portfolio = await _context.Portfolios.FindAsync(portfolioId);
            if (portfolio == null) return false;

            var trade = new Trade
            {
                PortfolioId = portfolioId,
                Symbol = symbol,
                Quantity = quantity,
                TradeType = TradeType.BUY,
                Price = share.Price
            };

            await _context.Trades.AddAsync(trade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SellShares(int portfolioId, string symbol, int quantity)
        {
            var share = await _context.Shares.FirstOrDefaultAsync(s => s.Symbol == symbol);
            if (share == null) return false;

            var portfolio = await _context.Portfolios.Include(p => p.Trades).FirstOrDefaultAsync(p => p.PortfolioId == portfolioId);
            if (portfolio == null) return false;

            var totalBought = portfolio.Trades.Where(t => t.Symbol == symbol && t.TradeType == TradeType.BUY).Sum(t => t.Quantity);
            var totalSold = portfolio.Trades.Where(t => t.Symbol == symbol && t.TradeType == TradeType.SELL).Sum(t => t.Quantity);
            var availableShares = totalBought - totalSold;

            if (availableShares < quantity) return false;

            var trade = new Trade
            {
                PortfolioId = portfolioId,
                Symbol = symbol,
                Quantity = quantity,
                TradeType = TradeType.SELL,
                Price = share.Price
            };

            await _context.Trades.AddAsync(trade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
