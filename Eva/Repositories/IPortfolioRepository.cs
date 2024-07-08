using Eva.Models;

namespace Eva.Repositories
{
    public interface IPortfolioRepository
    {
        Task<Portfolio> GetByIdAsync(int portfolioId);
    }
}
