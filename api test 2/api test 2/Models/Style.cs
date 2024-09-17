using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_test_2.Models
{
    public class Style
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StyleId { get; set; }
        public string Name { get; set; }
    }
}
