using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eva.Models
{
    public class Trade
    {
        [Key]
        [Required]
        public int TradeId { get; set; }

        [Required]
        public int PortfolioId { get; set; }

        [ForeignKey("PortfolioId")]
        public Portfolio Portfolio { get; set; }

        [Required]
        [StringLength(3)]
        public string Symbol { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public TradeType TradeType { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
    }
}
