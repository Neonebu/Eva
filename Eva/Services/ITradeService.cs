namespace Eva.Services
{
    public interface ITradeService
    {
        Task<bool> BuyShares(int portfolioId, string symbol, int quantity);
        Task<bool> SellShares(int portfolioId, string symbol, int quantity);
    }
}
