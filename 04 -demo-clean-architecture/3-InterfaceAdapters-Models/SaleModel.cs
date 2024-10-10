using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_InterfaceAdapters_Models
{
    public class SaleModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Total { get; set; }
        public List<ConceptModel> Concepts { get; set; }
    }
}
