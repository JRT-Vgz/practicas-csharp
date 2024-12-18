
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _3_Models
{
    public class BeerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Alcohol { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [ForeignKey("BrandId")]
        public BrandModel Brand { get; set; }
    }
}
