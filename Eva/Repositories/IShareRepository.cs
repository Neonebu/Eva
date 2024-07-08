using Eva.Models;

namespace Eva.Repositories
{
    public interface IShareRepository
    {
        Task<Share> GetBySymbolAsync(string symbol);
    }
}
