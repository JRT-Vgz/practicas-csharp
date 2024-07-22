using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libPedidos
{
    public interface intRepositorioProductos
    {
        public Dictionary<string, recProductos> ObtenTodos();
    }
}
