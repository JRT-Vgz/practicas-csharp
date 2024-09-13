using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_API_1.Models
{
    public class Band
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BandID { get; set; }
        public string Name { get; set; }
        public int StyleID { get; set; }
        [ForeignKey("StyleID")]
        public Style Style { get; set; }

    }
}
