
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _3_Models
{
    public class ConceptModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdBeer { get; set; }
        public int IdSale { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("IdBeer")]
        public BeerModel Beer { get; set; }

        [ForeignKey("IdSale")]
        public SaleModel Sale { get; set; }
    }
}
