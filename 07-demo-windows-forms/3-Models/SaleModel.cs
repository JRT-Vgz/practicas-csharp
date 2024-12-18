
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _3_Models
{
    public class SaleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ConceptModel> Concepts { get; set; }
    }
}
