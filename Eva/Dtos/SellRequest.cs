namespace Eva.Dtos
{
    public class SellRequest
    {
        public string UserEmail { get; set; }
        public int PortfolioId { get; set; }
        public string Symbol { get; set; }
        public int Quantity { get; set; }
    }
}
