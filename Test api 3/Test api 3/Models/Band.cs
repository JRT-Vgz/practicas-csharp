using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_api_3.Models
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
