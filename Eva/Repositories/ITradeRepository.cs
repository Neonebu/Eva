using Eva.Models;

namespace Eva.Repositories
{
    public interface ITradeRepository
    {
        Task AddAsync(Trade trade);
        Task<int> GetTotalBoughtAsync(int portfolioId, string symbol);
        Task<int> GetTotalSoldAsync(int portfolioId, string symbol);
    }
}
