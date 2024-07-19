using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libPedidos
{
    public class ctrObtenProductos
    {
        #region Propiedades
        private clsRepositorioMemProductos repoProductos;
        public Dictionary<string, recProductos> Productos { get; set; }
        #endregion

        #region Constructor
        public ctrObtenProductos()
        {
            repoProductos = new clsRepositorioMemProductos();
            Productos = new Dictionary<string, recProductos>();
        }
        #endregion

        #region Metodos
        public void ObtenProductos()
        {
            Productos.Clear();
            Productos = repoProductos.ObtenTodos();
        }

        public bool ObtenProducto(string codigoBarras, out recProductos producto)
        {
            return Productos.TryGetValue(codigoBarras, out producto);
        }
        #endregion
    }
}
