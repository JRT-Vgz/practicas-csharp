using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_InterfaceAdapters_Models
{
    public class SaleModel
    {
        public int Id { get; }
        public DateTime CreationDate { get; }
        public decimal Total { get; }
        public List<ConceptModel> Concepts { get; set; }
    }
}
