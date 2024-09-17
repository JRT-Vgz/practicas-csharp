using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_api_3.Models
{
    public class Style
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StyleID { get; set; }
        public string Name { get; set; }
    }
}
