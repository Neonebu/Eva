namespace Eva.Services
{
    public interface ITradeService
    {
        Task<bool> BuyShares(string userEmail, int portfolioId, string symbol, int quantity);
        Task<bool> SellShares(string userEmail, int portfolioId, string symbol, int quantity);
    }
}
