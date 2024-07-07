using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Eva.Models
{
    public class Portfolio
    {
        [Key]
        [Required]
        public int PortfolioId { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        public ICollection<Trade> Trades { get; set; }
    }
    public enum TradeType
    {
        BUY,
        SELL
    }
}
