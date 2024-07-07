using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eva.Models
{
    public class Share
    {
        [Key]
        [StringLength(3)]
        [Required]
        public string Symbol { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
    }

}
