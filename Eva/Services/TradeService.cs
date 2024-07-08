using Eva.Context;
using Eva.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Eva.Repositories;

namespace Eva.Services
{
    public class TradeService : ITradeService
    {
        private readonly IShareRepository _shareRepository;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly ITradeRepository _tradeRepository;

        public TradeService(IShareRepository shareRepository, IPortfolioRepository portfolioRepository, ITradeRepository tradeRepository)
        {
            _shareRepository = shareRepository;
            _portfolioRepository = portfolioRepository;
            _tradeRepository = tradeRepository;
        }

        public async Task<bool> BuyShares(int portfolioId, string symbol, int quantity)
        {
            var share = await _shareRepository.GetBySymbolAsync(symbol);
            if (share == null) return false;

            var portfolio = await _portfolioRepository.GetByIdAsync(portfolioId);
            if (portfolio == null) return false;

            var trade = new Trade
            {
                PortfolioId = portfolioId,
                Symbol = symbol,
                Quantity = quantity,
                TradeType = TradeType.BUY,
                Price = share.Price
            };

            await _tradeRepository.AddAsync(trade);
            return true;
        }

        public async Task<bool> SellShares(int portfolioId, string symbol, int quantity)
        {
            var share = await _shareRepository.GetBySymbolAsync(symbol);
            if (share == null) return false;

            var portfolio = await _portfolioRepository.GetByIdAsync(portfolioId);
            if (portfolio == null) return false;

            var totalBought = await _tradeRepository.GetTotalBoughtAsync(portfolioId, symbol);
            var totalSold = await _tradeRepository.GetTotalSoldAsync(portfolioId, symbol);
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

            await _tradeRepository.AddAsync(trade);
            return true;
        }
    }
}
